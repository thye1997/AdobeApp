using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TrainingApp.Models
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { set; get; }

        [Required]
        [MaxLength(50)]
        public string Name { set; get; }

        public int Age { set; get; }

        [Required]
        [MaxLength(50)]
        public string University { set; get; }
       
        public ICollection<Course> Course { set; get; }
    }
}