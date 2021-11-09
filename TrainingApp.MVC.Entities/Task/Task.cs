using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingApp.MVC.Entities.Shared;

namespace TrainingApp.MVC.Entities
{
   public class Task : Entity
    {
        public string TaskName { set; get; }

        public string TaskStatus { set; get; }

        [ForeignKey("User")]
        public int UserId { set; get; }

        public virtual User User { set; get; }
    }
}
