using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using TrainingApp.MVC.Entities;

namespace TrainingApp.MVC.ViewModel
{
    public class ContactBaseVM
    {
        public int Id { set; get; }

        [Required(ErrorMessage = "First Name is required...")]
        public string FirstName { set; get; }

        [Required(ErrorMessage = "Last Name is required...")]
        public string LastName { set; get; }

        //[Required(ErrorMessage ="Profile Image is required...")]
        //public HttpPostedFileBase AvatarImage { set; get; }
        public byte[] AvatarImageByte { set; get; }

        [Required(ErrorMessage = "Email is required...")]
        public string Email { set; get; }

        [Required(ErrorMessage = "Phone Number is required...")]
        public string PhoneNumber { set; get; }

        [Required(ErrorMessage = "Category is required...")]
        public string Category { set; get; }

        [Required(ErrorMessage = "Hour Rate is required...")]
        public int HourRate { set; get; }
    }

    public class ContactVM
    {
       public List<ContactBaseVM> ContactVMList { set; get; }

       public ContactBaseVM AddContactVM { set; get; }

        public int TotalRow { set; get; }

        public int TotalPage { set; get; }

        public int CurrentPage { set; get; }

    }

    public class ContactDetailVM
    {
        public int Id { set; get; }

        public string FirstName { set; get; }

        public string LastName { set; get; }

        public byte[] AvatarImageByte { set; get; }

        public string Email { set; get; }

        public string PhoneNumber { set; get; }

        public string Category { set; get; }

        public int HourRate { set; get; }

        public TaskBaseVM AddTask { set; get; }

        public List<Task> TaskList { set; get; }

    }
}
