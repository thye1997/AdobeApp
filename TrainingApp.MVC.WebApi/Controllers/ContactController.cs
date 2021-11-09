using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Http;
using TrainingApp.MVC.Business;
using TrainingApp.MVC.ViewModel;
using HttpGetAttribute = System.Web.Http.HttpGetAttribute;
using RoutePrefixAttribute = System.Web.Http.RoutePrefixAttribute;

namespace TrainingApp.MVC.WebApi.Controllers
{
    [RoutePrefix("api/Contact")]

    public class ContactController : ApiController
    {
        private readonly IUserComponent _userComponent;
        public ContactController(IUserComponent userComponent)
        {
            _userComponent = userComponent;
        }

        [System.Web.Http.HttpGet]
        public IHttpActionResult List()
        {
            var result = _userComponent.GetContactList();
            return Ok(result);
        }

        [Route("Detail/{id}")]
        [System.Web.Http.HttpGet]
        public IHttpActionResult Detail (int Id)
        {
            var result = _userComponent.GetContactDetail(Id);
            return Ok(result);
        }

        [HttpPost]
        public IHttpActionResult AddContact(ContactVM contactVM)
        {
            _userComponent.AddContact(contactVM);
            return Ok(true);
        }

        [HttpPost]
        [Route("AddTask")]
        public IHttpActionResult AddTask(ContactDetailVM contactVM)
        {
            Debug.WriteLine($"{contactVM.Id}");
            _userComponent.AddTask(contactVM);
            return Ok(true);
        }

        [HttpPost]
        [Route("EditTask")]
        public IHttpActionResult EditTask(EditTaskVM editTaskVM)
        {
            _userComponent.EditTask(editTaskVM);
            return Ok(true);
        }

        [Route("Sort/{sortKeyword}")]
        [System.Web.Http.HttpGet]
        public IHttpActionResult Sort (string sortKeyword)
        {
            var result = _userComponent.GetContactListBySort(sortKeyword);
            return Ok(result);
        }
    }
}