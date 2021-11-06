using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingApp.MVC.ViewModel.Course
{
  public class AddCourseVM
    {
        [Required(ErrorMessage = "Course name is required...")]
        [RegularExpression(@"^[a-zA-Z][a-zA-Z0-9-\s_-]*$", ErrorMessage = "Invalid Course Name Format...")]
        public string CourseName { set; get; }

        public string Grade { set; get; }

        public bool IsPassed { set; get; }

        public int UserId { set; get; }
    }
}
