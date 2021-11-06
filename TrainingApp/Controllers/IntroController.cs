using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrainingApp.Models;
using TrainingApp.Services;
using TrainingApp.ViewModel;

namespace TrainingApp.Controllers
{
    public class IntroController : Controller
    {
        // GET: Intro
        public ActionResult Index()
        {
            var userService = new UserService();
            return View(userService.GetUserDetail());
        }

        [HttpPost]
        public ActionResult AddCourse(UserCourseViewModel viewModel)
        {
            var userService = new UserService();
            if (ModelState.IsValid)
            {
                ViewBag.onAddCourse = true;
                userService.AddNewCourse(viewModel);
              return  View("Index", userService.GetUserDetail());
            }
            ViewBag.onAddCourse = false;
            return View("Index", userService.GetUserDetail());
        }
    }
}