using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Model;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
namespace Domain.Services
{
    public class CourseService
    {
        public async Task<IEnumerable<Course>> GetAvailableCourses(User user)
        {
            var context = new AcademiaContext();
            var studentIdParameter = new SqlParameter("@id_alumno", user.Id);
            var courses = await context.Courses.FromSqlRaw<Course>("GetAvailableCourses @id_alumno", studentIdParameter).ToListAsync();
            foreach (var course in courses)
            {
                await context.Entry(course).Reference(c => c.Subject).LoadAsync();
            }
            return courses;
        }

        public async Task<IEnumerable<Course>> GetAll()
        {
            var context = new AcademiaContext();
            var courses = await context.Courses.Include(c => c.Subject).ToListAsync();
            return courses;
        }

        public void Create(Course course)
        {
            try
            {
                var context = new AcademiaContext();
                context.Courses.Add(course);
                context.SaveChanges();
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public void Update(Course course)
        {
            try
            {
                var context = new AcademiaContext();
                var existingCourse = context.Courses.Find(course.Id);
                if (existingCourse != null)
                {
                    context.Entry(existingCourse).CurrentValues.SetValues(course);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public void Delete(Course course)
        {
            try
            {
                var context = new AcademiaContext();
                var existingCourse = context.Courses.Find(course.Id);
                if (existingCourse != null)
                {
                    context.Courses.Remove(existingCourse);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public void Add(Course course)
        {
            try
            {
                var context = new AcademiaContext();
                context.Courses.Add(course);
                context.SaveChanges();
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}
