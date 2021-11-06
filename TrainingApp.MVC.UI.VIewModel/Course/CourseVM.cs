using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace TrainingApp.MVC.UI.VIewModel.Course
{
   public class CourseVM
    {
        public string CourseName { set; get; }

        [DisplayName("Result")]
        public string Grade { set; get; }
        public bool IsPassed { set; get; }
    }
}
