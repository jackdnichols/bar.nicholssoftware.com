﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace bar.nicholssoftware.com.Controllers
{
    public class SignUpController : Controller
    {
        // GET: SignUp
        public ActionResult Index()
        {
            return View();
        }

        // GET: SignUp/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SignUp/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SignUp/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: SignUp/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SignUp/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: SignUp/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SignUp/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        [Route("SaveCompany")]
        public JsonResult SaveCompany([System.Web.Http.FromBody] Bar.Business.Companys company)
        {
            List<Bar.Business.Companys> companyList = null;

            if (company != null && !String.IsNullOrEmpty(company.Company_Name))
            {
                companyList = Bar.Business.Companys.GetCompanysByCompany_Name(company.Company_Name);
                if (companyList != null && companyList.Count > 0)
                {
                    Bar.Business.Companys.Update(company);
                }
                else
                {
                    Bar.Business.Companys.Insert(company);
                }
            }

            return Json(companyList, JsonRequestBehavior.AllowGet);
        }
    }
}
