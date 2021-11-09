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

        ContactVM GetContactList();

        ContactDetailVM GetContactDetail(int Id);

        void EditTaskStatus(EditTaskVM editTaskVM);

        void AddTask(ContactDetailVM contactDetailVM);

        ContactVM GetContactBySort(string sortKeyword);

        void AddContact(ContactVM contactVM);
    }
}
