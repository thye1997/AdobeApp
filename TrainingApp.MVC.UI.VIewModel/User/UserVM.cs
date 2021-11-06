using System;
using System.Collections.Generic;
using System.Text;
using TrainingApp.MVC.UI.VIewModel.Course;

namespace TrainingApp.MVC.UI.VIewModel.User
{
   public class UserVM
    {
        public string Name { set; get; }

        public int Age { set; get; }

        public string University { set; get; }
    }


    public class UserCourseVM {    
        public UserVM UserVM { set; get; }
        public CourseVM CourseVM { set; get; }
    
    }

}
