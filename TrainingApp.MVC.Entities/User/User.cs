using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TrainingApp.MVC.Entities.Shared;

namespace TrainingApp.MVC.Entities
{
    public class User : Entity
    {
        [MaxLength(50)]
        public string Name { set; get; }

        public int Age { set; get; }

        [MaxLength(50)]
        public string University { set; get; }

        public ICollection<Course> Course { set; get; }
    }
}
