using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using TrainingApp.Validation;

namespace TrainingApp.Models
{
    public class Course
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { set; get; }

        [Required (ErrorMessage ="Course name is required...")]
        [RegularExpression(@"^[a-zA-Z][a-zA-Z0-9-\s_-]*$", ErrorMessage ="Invalid Course Name Format...")]
        [MaxLength(50)]
        public string CourseName { set; get; }

        [Required (ErrorMessage ="Grade is required...")]
        [GradeValidation]
        [MaxLength(10)]
        public string Grade { set; get; }

        [Required]
        public bool IsPassed { set; get; }

        [Required]
        [ForeignKey("User")]
        public int UserId { set; get; }

        public virtual User User { set; get; }
    }
}