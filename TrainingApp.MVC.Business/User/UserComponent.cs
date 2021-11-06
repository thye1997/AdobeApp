using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using TrainingApp.MVC.DTO;
using TrainingApp.MVC.Entities;
using TrainingApp.MVC.ViewModel;

namespace TrainingApp.MVC.Business
{
    public class UserComponent : IUserComponent
    {
        private readonly IUnitOfWork _unitOfWork;
        public UserComponent(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public UserCourseDTO Get(int Id)
        {
           /* var userDTO = _unitOfWork.Repository.GetQuery<User>(c => c.Id == Id).Select(c => new MockUserDTO
            {
                Id = c.Id,
                Name = c.Name,
                Age = c.Age,
                University = c.University,
                Course = c.Course.ToList()
            }).FirstOrDefault();*/
            var userDTO = _unitOfWork.Repository.GetQuery<User>(c => c.Id == Id).Select(c => new UserCourseDTO
                {
                    Id = c.Id,
                    Name = c.Name,
                    Age = c.Age,
                    University = c.University,
                }).FirstOrDefault();

            userDTO.CourseDTO = _unitOfWork.Repository.GetQuery<Course>(c => c.UserId == userDTO.Id)
                    .Select(c => new CourseDTO
                    {
                        CourseName = c.CourseName,
                        Grade = c.Grade,
                        IsPassed = c.IsPassed
                    }).ToList();

            return userDTO;
        }

        public void AddCourse(UserVM userVM)
        {
            var course = new Course
            {
                CourseName = userVM.AddCourseVM.CourseName,
                Grade = userVM.AddCourseVM.Grade,
                IsPassed = userVM.AddCourseVM.Grade.Equals("Passed"),
                UserId = userVM.Id,
            };
            using (TransactionScope trans = new TransactionScope())
            {
                _unitOfWork.Repository.Insert<Course>(course);
                _unitOfWork.Save();
                trans.Complete();
            };              
        }



        /* private UserCourseDTO ManualDTOMapper(User user)
         {
             var courseDTO = new UserCourseDTO
             {
                 Id = user.Id,
                 Name = user.Name,
                 Age = user.Age,
                 University = user.University,
                 CourseDTO = ManualMapCourseDTO(user.Course.ToList())
             };

             return courseDTO;
         }

         private List<CourseDTO> ManualMapCourseDTO (List<Course> course)
         {
             var courseDTO = from c in course
                             select new CourseDTO
                             {
                                 CourseName = c.CourseName,
                                 Grade = c.Grade,
                                 IsPassed = c.IsPassed
                             };

             return courseDTO.ToList();
         }*/
    }

    public class MockUserDTO
    {
        public int Id { set; get; }

        public string Name { set; get; }

        public int Age { set; get; }

        public string University { set; get; }

        public List<Course> Course { set; get; }
    }
}
