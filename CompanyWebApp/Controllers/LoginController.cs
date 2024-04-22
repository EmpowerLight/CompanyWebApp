using CompanyWebApp.Models;
using CompanyWebApp.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace CompanyWebApp.Controllers
{
    public class LoginController : Controller
    {
        AccessService service = new AccessService();
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(LoginModel model)
        {
            if(ModelState.IsValid)
            {

                if(service.LoginUser(model))
                {
                    FormsAuthentication.SetAuthCookie(model.Email, false);
                    return RedirectToAction("Index", "Company");
                }else
                {
                    ModelState.AddModelError("Email", "Wrong email or password please check again!");
                    return View(model);
                }
            }
            return View(model);
        }

        //Get
        public ActionResult logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index");
        }

    }
}