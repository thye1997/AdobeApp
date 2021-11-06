using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TrainingApp.Database.CodeFIrst;
using TrainingApp.Models;
using TrainingApp.ViewModel;

namespace TrainingApp.Services
{
    public class UserService
    {

       public UserCourseViewModel GetUserDetail()
        {
            using (var context = new CodeFirstContext())
            {
                var viewModel = context.User.AsQueryable().Where(c => c.Id == 1).Select(c => new UserCourseViewModel
                {
                    UserId = c.Id,
                    Name = c.Name,
                    Age = c.Age,
                    UniversityName = c.University,
                    CourseList = c.Course.ToList()
                }).FirstOrDefault();

                return viewModel;
            }
        }

        public void AddNewCourse(UserCourseViewModel viewModel)
        {
            using (var context = new CodeFirstContext())
            {
                var course = new Course
                {
                    CourseName = viewModel.Course.CourseName,
                    Grade = viewModel.Course.Grade,
                    UserId = viewModel.UserId,
                    IsPassed = viewModel.Course.Grade.Equals("Passed")
                };
                context.Course.Add(course);
                context.SaveChanges();

            }
        }
    }
}