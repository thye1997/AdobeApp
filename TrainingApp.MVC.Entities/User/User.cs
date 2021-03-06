using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TrainingApp.MVC.Entities.Shared;

namespace TrainingApp.MVC.Entities
{
    public class User : Entity
    {
        [MaxLength(50)]
        public string FirstName { set; get; }

        public string LastName { set; get; }

        public byte [] AvatarImage { set; get; }

        public string Email { set; get; }

        public string PhoneNumber { set; get; }

        public string Category { set; get; }

        public int HourRate { set; get; }

        public ICollection<Task> Task { set; get; }
    }
}
