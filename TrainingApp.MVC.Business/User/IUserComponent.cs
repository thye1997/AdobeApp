using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingApp.MVC.DTO;
using TrainingApp.MVC.Entities;
using TrainingApp.MVC.ViewModel;

namespace TrainingApp.MVC.Business
{
   public interface IUserComponent
    {
        UserCourseDTO Get(int Id);

        void AddCourse(UserVM userVM);

        ContactVM GetContactList();

        ContactDetailVM GetContactDetail(int Id);

        ContactVM GetContactListBySort(string sortKeyword);

        void AddContact(ContactVM contactVM);

        void AddTask(ContactDetailVM contactVM);

        void EditTask(EditTaskVM editTaskVM);

    }
}
