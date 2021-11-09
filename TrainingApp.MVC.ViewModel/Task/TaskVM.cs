using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using TrainingApp.MVC.Entities;
namespace TrainingApp.MVC.ViewModel
{
   public class TaskBaseVM
    {
        public int TaskId { set; get; }

        [Required(ErrorMessage ="Task Name is required...")]
        public string TaskName { set; get; }

        [Required(ErrorMessage = "Task Status is required...")]
        public string TaskStatus { set; get; }

    }


    public class EditTaskVM
    {
        public int TaskId { set; get; }

        public int UserId { set; get; }

        public string Status { set; get; }
    }


}
