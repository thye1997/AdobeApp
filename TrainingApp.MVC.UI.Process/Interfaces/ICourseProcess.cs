using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingApp.MVC.ViewModel;

namespace TrainingApp.MVC.UI.Process.Interfaces
{
   public interface ICourseProcess
    {
        CourseVM GetCourseList(int userId);

        void RegisterCourse(CourseVM course);
    }
}
