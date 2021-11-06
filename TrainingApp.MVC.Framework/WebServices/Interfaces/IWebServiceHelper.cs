using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;

namespace TrainingApp.MVC.Framework.WebServices.Interfaces
{
   public interface IWebServiceHelper
    {
        IRestResponse<T> Execute<T>(string apiPath, Method method, object requestContent=null);
    }
}
