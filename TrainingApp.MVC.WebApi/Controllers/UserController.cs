using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TrainingApp.MVC.Business;
using TrainingApp.MVC.ViewModel;

namespace TrainingApp.MVC.WebApi.Controllers
{
    [RoutePrefix("api/User")]
    public class UserController : ApiController
    {
        // GET api/<controller>
        private readonly IUserComponent _userComponent;
        public UserController(IUserComponent userComponent)
        {
            _userComponent = userComponent;
        }
        
        public IHttpActionResult GetUserDetail(int Id)
        {
            var result = _userComponent.Get(Id);
            return Ok(result);
        }

        [HttpPost]
        public IHttpActionResult AddCourse(UserVM userVM)
        {
            _userComponent.AddCourse(userVM);
            return Ok(true);
        }
    }
}