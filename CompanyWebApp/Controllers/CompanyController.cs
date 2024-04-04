using CompanyWebApp.Models;
using CompanyWebApp.Service;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CompanyWebApp.Controllers
{
    public class CompanyController : Controller
    {
        CompanyService service = new CompanyService();
        // GET: Company
        public ActionResult Index()
        {
            var data = service.ListCompany();
            return View(data);
        }

        // Get
        public ActionResult Create()
        {
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
            var data = service.ListCompany().Find(c => c.Id == id);
            return View(data);
        }

        // Get
        public ActionResult CompaniesInfoIndex()
        {
            var data = service.ListCompanyInfo();
            return View(data);
        }

        //Get
        public ActionResult CreateCompanyInfo()
        {
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
                company.Attachment = fileName;
                
            }

           if (service.CreateCompanyInfo(company))
            {
                TempData["InfoSucess"] = "Sucessfully Created";
                return RedirectToAction("CompaniesInfoIndex");
            }
            return View(company);
        }

        // Get
        public ActionResult UpdateCompanyInfo(int? cid)
        {
            var data = service.ListCompanyInfo().Find(c => c.Cid == cid);
            return View(data);
        }

        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateCompanyInfo(CompanyInfoModel model)
        {
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

    } 
}