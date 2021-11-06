using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingApp.MVC.Entities.Shared;

namespace TrainingApp.MVC.Entities
{
   public class Course : Entity
    {
        
        [MaxLength(50)]
        public string CourseName { set; get; }

        //[GradeValidation]
        [MaxLength(10)]
        public string Grade { set; get; }

        public bool IsPassed { set; get; }

        [ForeignKey("User")]
        public int UserId { set; get; }
        
        public virtual User User { set; get; }
    }
}
