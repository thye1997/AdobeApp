using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using TrainingApp.MVC.DTO;
using TrainingApp.MVC.Entities;
using TrainingApp.MVC.ViewModel;
using Task = TrainingApp.MVC.Entities.Task;

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
           /* var userDTO = _unitOfWork.Repository.GetQuery<User>(c => c.Id == Id).Select(c => new UserCourseDTO
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
                    }).ToList();*/

            return null;
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

        public ContactVM GetContactList()
        {
            var contactList = _unitOfWork.Repository.GetQuery<User>(null).Take(6).ToList();

            var contactVM = new ContactVM();
            contactVM.ContactVMList = ManualDTOMapper(contactList);

            decimal totalPage = decimal.Divide(_unitOfWork.Repository.GetQuery<User>(null).Count(),6);
            contactVM.TotalPage = (int)Math.Ceiling(totalPage);
            contactVM.CurrentPage = 1;
            return contactVM;
        }


        public List<ContactBaseVM> ManualDTOMapper(List<User> user)
        {
            var contactVM = new ContactVM();
            return contactVM.ContactVMList = (from u in user
                              select new ContactBaseVM
                              {
                                  Id = u.Id,
                                  FirstName = u.FirstName,
                                  LastName = u.LastName,
                                  AvatarImageByte = u.AvatarImage,
                                  Email = u.Email,
                                  HourRate = u.HourRate,
                                  Category = u.Category,
                                  PhoneNumber = u.PhoneNumber
                              }).ToList();
        }

        public void AddContact(ContactVM contactVM)
        {
            var user = new User
            {
                FirstName = contactVM.AddContactVM.FirstName,
                LastName = contactVM.AddContactVM.LastName,
                Email = contactVM.AddContactVM.Email,
                AvatarImage = contactVM.AddContactVM.AvatarImageByte,
                PhoneNumber = contactVM.AddContactVM.PhoneNumber,
                Category = contactVM.AddContactVM.Category,
                HourRate = contactVM.AddContactVM.HourRate,
            };
            using (TransactionScope trans = new TransactionScope())
            {
                _unitOfWork.Repository.Insert<User>(user);
                _unitOfWork.Save();
                trans.Complete();
            };
        }

        public ContactVM GetContactListBySort(string sortKeyword)
        {
            var queryable = _unitOfWork.Repository.GetQuery<User>(null);

            var contactVM = new ContactVM();

            switch (sortKeyword)
            {
                case "Name":
        contactVM.ContactVMList= ManualDTOMapper (queryable.OrderBy(c => c.FirstName).Take(6).ToList());
                    break;
                case "Category":
        contactVM.ContactVMList = ManualDTOMapper(queryable.OrderBy(c => c.Category).Take(6).ToList());
                    break;
                case "Salary":
        contactVM.ContactVMList = ManualDTOMapper(queryable.OrderBy(c => c.HourRate).Take(6).ToList());
                    break;
                default:
        contactVM.ContactVMList = ManualDTOMapper(queryable.Take(6).ToList());
                    queryable.ToList();
                    break;
            }

            decimal totalPage = decimal.Divide(_unitOfWork.Repository.GetQuery<User>(null).Count(), 6);
            contactVM.TotalPage = (int)Math.Ceiling(totalPage);
            contactVM.CurrentPage = 1;
            return contactVM;
        }

        public ContactDetailVM GetContactDetail(int Id)
        {
            var result = _unitOfWork.Repository.GetQuery<User>(null).Where(c=>c.Id==Id)
                .Select( d=> new ContactDetailVM
                {
                    Id = d.Id,
                    FirstName = d.FirstName,
                    LastName = d.LastName,
                    AvatarImageByte = d.AvatarImage,
                    Category = d.Category,
                    Email = d.Email,
                    PhoneNumber = d.PhoneNumber,
                    HourRate = d.HourRate,
                    TaskList = d.Task.ToList()
                }
                ).FirstOrDefault();                   
            return result;
        }

        public void AddTask(ContactDetailVM contactVM)
        {
            var task = new Entities.Task
            {
                TaskName = contactVM.AddTask.TaskName,
                TaskStatus = contactVM.AddTask.TaskStatus,
                UserId = contactVM.Id        
            };
            using (TransactionScope trans = new TransactionScope())
            {
                _unitOfWork.Repository.Insert(task);
                _unitOfWork.Save();
                trans.Complete();
            };
        }

        public void EditTask(EditTaskVM editTaskVM)
        {
            var query = _unitOfWork.Repository.GetQuery<Task>(c=>c.UserId == editTaskVM.UserId).ToList();
            if (query != null)
            {
                using (TransactionScope trans = new TransactionScope())
                {
                    foreach(var n in query.ToList())
                    {
                        if(n.Id == editTaskVM.TaskId)
                        {
                            n.TaskStatus = editTaskVM.Status;
                            _unitOfWork.Save();
                            trans.Complete();
                        }
                    }
                    
                };
            }
        }
    }
}
