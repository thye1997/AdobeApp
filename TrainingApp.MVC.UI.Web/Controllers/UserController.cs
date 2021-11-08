using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RestSharp;
using TrainingApp.MVC.Framework.Constants;
using TrainingApp.MVC.Framework.WebServices.Interfaces;
using TrainingApp.MVC.UI.Process.Interfaces;
using TrainingApp.MVC.ViewModel;

namespace TrainingApp.MVC.UI.Web.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserProcess _userProcess;

        public UserController(IUserProcess userProcess)
        {
            _userProcess = userProcess;
        }

        // GET: User
        public ActionResult Index()
        {
            var data = _userProcess.Get(1);
            //Debug.WriteLine(data.CourseVMList[0].CourseName);
            return View(data);
        }

        [HttpPost]
        public ActionResult AddCourse(UserVM viewModel)
        {
            if (ModelState.IsValid)
            {
                TempData["onAddCourse"] = true;
                _userProcess.AddCourse(viewModel);
                return RedirectToAction("Index");
            }
            TempData["onAddCourse"] = false;
            return RedirectToAction("Index");
        }


    }

}