using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingApp.MVC.ViewModel
{
   public class CourseVM
    {
        public string CourseName { set; get; }

        public string Grade { set; get; }

        public bool IsPassed { set; get; }
    }
}
