using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TrainingApp.Models;

namespace TrainingApp.ViewModel
{
    public class UserCourseViewModel
    {
        public int UserId { set; get; }
        public string Name { set; get; }
        public int? Age { set; get; }
        public string UniversityName { set; get; }
        public List<Course> CourseList { set; get; }
        public Course Course { set; get; }
    }
}