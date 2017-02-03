using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EZLF.Models.ViewModels;
using EZLF.Models;
using EZLF.Services;
using EZLF.Class.Helpers;
using EZLF.Class;
using Postal;


namespace EZLF.Controllers
{
    public class HomeController : Controller
    {

        private IUserService acctSvc;
        public HomeController()
        {
            this.acctSvc = new UserService();
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            TestViewModel vm = new TestViewModel();
            ViewBag.Message = "Your application description page.";

            return View(vm);
        }

        public ActionResult Contact()
        {

            var model = new ContactModel();
            BaseServices baseSvc = (BaseServices)acctSvc; // cast to base class        
            var user= baseSvc.GetCurrentUser();
            model.FullName = user.FIRST + " " + user.LAST;
            model.Company = user.COMPANY;
            model.Phone = user.PHONE;
            model.Fax = user.FAX;
            model.Email = user.EMAIL;
            return View(model);
        }


        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Contact(ContactModel model)
        {
            dynamic email = new Email("Contact");
            email.To = model.Email;
            email.Subject = "ezLandlordForms.com Contact Form";
            email.From = "test@test.com";
            email.FullName = model.FullName;
            email.Message = model.Message;
            email.Phone = model.Phone;
            email.Send();
            return View(model);
        }

        [ChildActionOnly]
        public PartialViewResult Footer()
        {
            var model = new FooterModel();          
            return PartialView(model);
        }


        [ChildActionOnly]
        public PartialViewResult Header()
        {
            var model = new HeaderModel();
            return PartialView(model);
        }
    }
}