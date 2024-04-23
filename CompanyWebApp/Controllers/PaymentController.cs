using CompanyWebApp.Models;
using CompanyWebApp.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CompanyWebApp.Controllers
{
    public class PaymentController : Controller
    {
        private CompanyService service = new CompanyService();
        // GET: Payment
        public ActionResult Index()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Login");
            }
            ViewBag.AllPaymentTypes = new List<SelectListItem>
            {
                new SelectListItem { Value = "esewa", Text = "Esewa" },
                new SelectListItem { Value = "khati", Text = "Khati" }
            };

            return View();
        }

        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(PaymentModel model)
        {
            if(service.makePayment(model))
            {
                return RedirectToAction("Index", "Company");
            }
            return View(model);
        }

    }
}