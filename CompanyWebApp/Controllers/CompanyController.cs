using CompanyWebApp.Models;
using CompanyWebApp.Service;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace CompanyWebApp.Controllers
{
    public class CompanyController : Controller
    {
        CompanyService service = new CompanyService();
        // GET: Company
        public ActionResult Index()
        {
            if(!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Login");
            }
            var data = service.ListCompany();
            return View(data);
        }

        // Get
        public ActionResult Create()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Login");
            }
            return View();
        }

        // Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CompanyModel company)
        {
            if (service.CreateCompany(company))
            {
                TempData["sucess"] = "Sucessfully Created a Company";
                return RedirectToAction("Index");
            }

            return View(company);
        }

        //Get
        public ActionResult Update(int? id)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Login");
            }
            var data = service.ListCompany().Find(c => c.Id == id);
            return View(data);
        }

        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(CompanyModel company)
        {
            if (service.UpdateCompany(company))
            {
                TempData["sucess"] = "Sucessfully Updated";
                return RedirectToAction("Index");
            }
            return View(company);
        }

        //Get
        public ActionResult Delete(int? id)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Login");
            }
            var data = service.ListCompany().Find(c => c.Id == id);
            return View(data);
        }

        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(CompanyModel company)
        {
            if(service.DeleteCompany(company))
            {
                TempData["sucess"] = "Sucessfully deleted Company";
                return RedirectToAction("Index");
            }
            return View(company);
        }

        //Get
        public ActionResult Details(int? id)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Login");
            }
            var data = service.ListCompany().Find(c => c.Id == id);
            return View(data);
        }

        // Get
        public ActionResult CompaniesInfoIndex()
        {
            if(!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Login");
            }
            var data = service.ListCompanyInfo();
            return View(data);
        }

        //Get
        public ActionResult CreateCompanyInfo()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Login");
            }
            return View();
        }
        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateCompanyInfo(CompanyInfoModel company, HttpPostedFileBase attachmentFile)
        {
            if (attachmentFile != null && attachmentFile.ContentLength > 0)
            {
                string fileName = Path.GetFileName(attachmentFile.FileName);

                string directoryPath = Server.MapPath("~/Attachments");
                string filePath = Path.Combine(directoryPath, fileName);

                // Ensure directory exists or create it
                if (!Directory.Exists(directoryPath))
                {
                    Directory.CreateDirectory(directoryPath);
                }

                try
                {
                    attachmentFile.SaveAs(filePath);
                    company.Attachment = filePath;
                }
                catch (Exception ex)
                {
                    // Handle exception, log error, display message to user, etc.
                    TempData["ErrorMessage"] = "Failed to save attachment: " + ex.Message;
                    return View(company); // Redirect to an error handling action
                }
            }

            if (service.CreateCompanyInfo(company))
            {
                TempData["InfoSucess"] = "Successfully Created";
                return RedirectToAction("CompaniesInfoIndex");
            }
            return View(company);
        }

        // Get
        public ActionResult UpdateCompanyInfo(int? cid)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Login");
            }
            var data = service.ListCompanyInfo().Find(c => c.Cid == cid);
            return View(data);
        }

        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateCompanyInfo(CompanyInfoModel model, HttpPostedFileBase attachmentFile)
        {
            if (attachmentFile != null && attachmentFile.ContentLength > 0)
            {
                string fileName = Path.GetFileName(attachmentFile.FileName);
                string filePath = Path.Combine(Server.MapPath("~/Attachments"), fileName);

                attachmentFile.SaveAs(filePath);
                model.Attachment = filePath;
            }
            if (service.UpdateCompanyInfo(model))
            {
                TempData["InfoSucess"] = "Updated Sucessfully";
                return RedirectToAction("CompaniesInfoIndex");
            }
            return View(model);
        }

        //Get
        public ActionResult DeleteCompanyInfo(int? cid)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Login");
            }
            var data = service.ListCompanyInfo().Find(c => c.Cid == cid);
            return View(data);
        }

        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteCompanyInfo(CompanyInfoModel model)
        {
            if(service.DeleteCompanyInfo(model))
            {
                TempData["InfoSucess"] = "Sucessfully Deleted";
                return RedirectToAction("CompaniesInfoIndex");
            }
            return View(model);
        }

        // Get
        public ActionResult DetailCompanyInfo(int? cid)
        {
            var data = service.ListCompanyInfo().Find(c => c.Cid == cid);
            return View(data);
        }

        //Get
        public ActionResult DetailWholeCompany()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Login");
            }
            return View();
        }

        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DetailWholeCompany(DateTime dateTime)
        {
            List<WholeCompanyModel> model = service.WholeDetails(dateTime);
            return View(model);
        }

        //Get 
        public ActionResult DetailCompanyFromName()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Login");
            }
            return View();
        }

        //post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DetailCompanyFromName(string name)
        {
            List<WholeCompanyModel> model = service.WholeDetailsFromName(name);
            return View(model);
        }

        //Get
        public ActionResult CompanyExpiry()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("index", "Login");
            }
            List<WholeCompanyModel> model = service.getAboutExpireCompany();
            return View(model);
        }
    } 
}