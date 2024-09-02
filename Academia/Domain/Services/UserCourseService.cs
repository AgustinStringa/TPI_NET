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

                var context = new AcademiaContext();
                context.UserCourses.Add(userCourse);
                context.SaveChanges();
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}
