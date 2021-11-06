using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingApp.MVC.ViewModel.Course;

namespace TrainingApp.MVC.ViewModel
{
    public class UserVM
    {
        public int Id { set; get; }

        [DisplayName("Name")]
        public string Name { set; get; }

        [DisplayName("Age")]
        public string Age { set; get; }

        [DisplayName("University")]
        public string University { set; get; }

        public List<CourseVM> CourseVMList { set; get; }

        public AddCourseVM AddCourseVM { set; get; }

    }
}
