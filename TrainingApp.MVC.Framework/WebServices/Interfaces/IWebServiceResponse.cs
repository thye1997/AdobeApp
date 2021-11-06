using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;

namespace TrainingApp.MVC.Framework.WebServices.Interfaces
{

    /// <typeparam name="T">Type to deserialize the response content into.</typeparam>

    public interface IWebServiceResponse<T> : IRestResponse<T>
    {
    }
}
