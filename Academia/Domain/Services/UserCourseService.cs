using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class UserCourseService
    {
        public void Add(UserCourse userCourse)
        {
            try
            {
                using (var context = new AcademiaContext())
                {
                    if (IsUserAlreadyEnrolled(userCourse.UserId, userCourse.CourseId))
                    {
                        throw new InvalidOperationException("El usuario ya está inscrito en este curso.");
                    }

                    context.UserCourses.Add(userCourse);
                    context.SaveChanges();
                }
            }
            catch
            {
                throw;
            }
        }

        public bool IsUserAlreadyEnrolled(int userId, int courseId)
        {
            using (var context = new AcademiaContext())
            {
                return context.UserCourses.Any(uc => uc.UserId == userId && uc.CourseId == courseId);
            }
        }



    }
}
