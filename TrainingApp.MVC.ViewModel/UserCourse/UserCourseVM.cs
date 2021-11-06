using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingApp.MVC.ViewModel
{
    public class UserCourseVM
    {
        public UserVM UserVM { set; get; }

        public List<CourseVM> CourseVMList {set;get;}
    }
}
