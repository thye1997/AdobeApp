using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingApp.MVC.DTO
{
   public class UserCourseDTO
    {
        public int Id { set; get; }

        public string Name { set; get; }

        public int Age { set; get; }

        public string University { set; get; }

        public List<CourseDTO> CourseDTO { set; get; }
    }
}
