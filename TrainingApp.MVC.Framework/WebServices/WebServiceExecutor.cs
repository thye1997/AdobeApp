using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using TrainingApp.MVC.Framework.WebServices.Interfaces;

namespace TrainingApp.MVC.Framework.WebServices
{
    public class WebServiceExecutor : IWebServiceHelper
    {
        private static readonly string _baseUrl = "https://localhost:44380/";

        public IRestResponse<T> Execute<T>(string apiPath, Method method, object requestContent = null)
        {
            var client = CreateClient($"{_baseUrl}{apiPath}");

            var request = MapRquestContent(method, requestContent);
            IRestResponse<T> response = client.Execute<T>(request);
            return response;
        }

        private RestClient CreateClient(string baseUrl)
        {
            var client = new RestClient(baseUrl);

            return client;
        }

        public IRestRequest CreateJsonRestRequest(Method method, object obj)
        {
            var request = new RestRequest(method).AddJsonBody(obj);
            return request;
        }

        public IRestRequest CreateBasicRestRequest(Method method)
        {
            var request = new RestRequest(method);
            
            return request;
        }

        private IRestRequest MapRquestContent(Method method, object requestContent)
        {
            if (requestContent !=null)
            {
                return CreateJsonRestRequest(method, requestContent);
            }
            else
            {
                return CreateBasicRestRequest(method);
            }

        }
    }
}
