using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrainingApp.MVC.UI.Process.Interfaces;
using TrainingApp.MVC.ViewModel;

namespace TrainingApp.MVC.UI.Web.Controllers
{
    public class ContactController : Controller
    {
        private readonly IUserProcess _userProcess;
        public ContactController(IUserProcess userProcess)
        {
            _userProcess = userProcess;
        }
        // GET: Contact
        public ActionResult Index()
        {
            var contactList = _userProcess.GetContactList();
            return View(contactList);
        }

        public ActionResult Detail(int Id)
        {
            var contactList = _userProcess.GetContactDetail(Id);
            return View("ContactDetailView", contactList);
        }

        [HttpGet]
        public ActionResult Edit(string status, int id, int userId)
        {
            Debug.WriteLine($"{status} {id} {userId}");
            var editTaskVM = new EditTaskVM
            {
                TaskId = id,
                Status = status,
                UserId = userId
            };
            _userProcess.EditTaskStatus(editTaskVM);
            return RedirectToAction("Detail", new { Id = editTaskVM.UserId });
        }

        [Route("Sort/{sort}")]
        public ActionResult Sort(string sort)
        {
            var contactList = _userProcess.GetContactBySort(sort);
            return View("Index", contactList);
        }

        [HttpPost]
        public ActionResult AddContact(ContactVM viewModel, HttpPostedFileBase file)
        {
            var image = Image.FromStream(file.InputStream);
            
            Debug.WriteLine($"{file.ContentLength}");
            if (ModelState.IsValid)
            {
                TempData["onAddCourse"] = true;
                viewModel.AddContactVM.AvatarImageByte = ImageToByteArray(image);
                _userProcess.AddContact(viewModel);
                return RedirectToAction("Index");
            }
            TempData["onAddCourse"] = false;
            return RedirectToAction("Index");
        }

        [HttpPost]
        //[Route("AddTask")]
        public ActionResult AddTask(ContactDetailVM viewModel)
        {

            if (ModelState.IsValid)
            {
                _userProcess.AddTask(viewModel);
                return RedirectToAction("Detail", new { Id = viewModel.Id });
            }
            return RedirectToAction("Detail", new { Id = viewModel.Id });
        }



        public byte[] ImageToByteArray(Image imageIn)
        {
            using (var ms = new MemoryStream())
            {
                imageIn.Save(ms, imageIn.RawFormat);
                return ms.ToArray();
            }
        }


    }
}