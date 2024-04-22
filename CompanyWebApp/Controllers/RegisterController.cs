using CompanyWebApp.Models;
using CompanyWebApp.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CompanyWebApp.Controllers
{
    public class RegisterController : Controller
    {

        AccessService accessService = new AccessService();

        // GET: Register
        public ActionResult Index()
        {
            return View();
        }

        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                accessService.AddNewUser(model);
                return RedirectToAction("Index", "Login");
            }

            return View(model);
        }

    }
}