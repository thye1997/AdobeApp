using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestSharp;
using TrainingApp.MVC.DTO;
using TrainingApp.MVC.Framework.Constants;
using TrainingApp.MVC.Framework.WebServices.Interfaces;
using TrainingApp.MVC.UI.Process.Interfaces;
using TrainingApp.MVC.ViewModel;

namespace TrainingApp.MVC.UI.Process.Processes
{ 
    public class UserProcess : IUserProcess
    {
        private readonly IWebServiceHelper _service;
        public UserProcess(IWebServiceHelper service)
        {
            _service = service;
        }
        public UserVM Get(int Id)
        {
                string url = $"{ApiConstant.Path.Url.GetUserDetail}{Id}";

                var response = _service.Execute<UserCourseDTO>(url, Method.GET);

                var data = ManualVMMapper(response.Data);

                return data;          
        }

        public void AddCourse(UserVM userVM)
        {
                string url = $"{ApiConstant.Path.Url.AddCourse}";
                var response = _service.Execute<bool>(url, Method.POST, userVM);
        }

        private UserVM ManualVMMapper(UserCourseDTO userCourseDTO)
        {
            var userVM = new UserVM
            {
                Id = userCourseDTO.Id,
                Name = userCourseDTO.Name,
                Age = userCourseDTO.Age.ToString(),
                University = userCourseDTO.University,
                CourseVMList = CourseVMListMapper(userCourseDTO.CourseDTO)
            };
            return userVM;
        }

        private List<CourseVM> CourseVMListMapper(List<CourseDTO> courseDTO)
        {
            var courVMList = from cd in courseDTO
                             select new CourseVM
                             {
                                 CourseName = cd.CourseName,
                                 Grade = cd.Grade,
                                 IsPassed = cd.IsPassed
                             };
            return courVMList.ToList();
        }

        public ContactVM GetContactList()
        {
            string url = $"{ApiConstant.Path.Url.GetContactList}";
            var response = _service.Execute<ContactVM>(url, Method.GET);
            var content = JsonConvert.DeserializeObject<ContactVM>(response.Content);
            Debug.WriteLine($"{content.ContactVMList.Count}");
            return content;
        }

        public void AddContact(ContactVM contactVM)
        {
            string url = $"{ApiConstant.Path.Url.AddContact}";
            var response = _service.Execute<bool>(url, Method.POST, contactVM);

        }

        public ContactVM GetContactBySort(string sortKeyword)
        {
            string url = $"{ApiConstant.Path.Url.GetContactBySort}{sortKeyword}";
            var response = _service.Execute<ContactVM>(url, Method.GET);
            var content = JsonConvert.DeserializeObject<ContactVM>(response.Content);
            return content;
        }

        public ContactDetailVM GetContactDetail(int Id)
        {
            string url = $"{ApiConstant.Path.Url.GetContactDetail}{Id}";
            var response = _service.Execute<ContactDetailVM>(url, Method.GET);
            var content = JsonConvert.DeserializeObject<ContactDetailVM>(response.Content);
            return content;
        }

        public void AddTask(ContactDetailVM contactDetailVM)
        {
            string url = $"{ApiConstant.Path.Url.AddTask}";
            var response = _service.Execute<bool>(url, Method.POST, contactDetailVM);
        }

        public void EditTaskStatus(EditTaskVM editTaskVM)
        {
            string url = $"{ApiConstant.Path.Url.EditTask}";
            var response = _service.Execute<bool>(url, Method.POST, editTaskVM);
        }
    }
}
