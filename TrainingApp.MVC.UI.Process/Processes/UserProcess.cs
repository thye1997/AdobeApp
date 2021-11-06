using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            try
            {
                string url = $"{ApiConstant.Path.Url.GetUserDetail}{Id}";

                var response = _service.Execute<UserCourseDTO>(url, Method.GET);

                var data = ManualVMMapper(response.Data);

                return data;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return null;
            }
            
        }

        public void AddCourse(UserVM userVM)
        {
            try
            {
                string url = $"{ApiConstant.Path.Url.AddCourse}";
                var response = _service.Execute<bool>(url, Method.POST, userVM);
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
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


    }
}
