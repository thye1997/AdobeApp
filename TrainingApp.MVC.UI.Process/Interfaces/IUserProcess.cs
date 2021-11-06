using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingApp.MVC.ViewModel;

namespace TrainingApp.MVC.UI.Process.Interfaces
{
   public interface IUserProcess
    {
        UserVM Get(int Id);

        void AddCourse(UserVM userVM);
    }
}
