using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingApp.MVC.Entities;

namespace TrainingApp.MVC.DTO
{
   public class ContactDTO
    {
        public string FirstName { set; get; }

        public string LastName { set; get; }

        public byte[] AvatarImage { set; get; }

        public string Email { set; get; }

        public string PhoneNumber { set; get; }

        public string Category { set; get; }

        public int HourRate { set; get; }

        public List<Entities.Task> Task { set; get; }
    }
}
