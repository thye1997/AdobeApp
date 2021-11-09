using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingApp.MVC.Framework.Constants
{
   public class ApiConstant
    {
        public class Path
        {
            public static class Url
            {
                public const string GetUserDetail = "api/User/GetUserDetail/?id=";
                public const string AddCourse = "api/User/AddCourse/";

                public const string AddContact = "api/Contact/AddContact/";
                public const string AddTask = "api/Contact/AddTask/";

                public const string EditTask = "api/Contact/EditTask/";

                public const string GetContactBySort = "api/Contact/Sort/";
                public const string GetContactList = "api/Contact/List";
                public const string GetContactDetail = "api/Contact/Detail/";

            }

        }
    }
}
