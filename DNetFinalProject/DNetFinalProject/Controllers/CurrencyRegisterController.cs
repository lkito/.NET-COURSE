using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DNetFinalProject.Models;

namespace DNetFinalProject.Controllers
{
    public class CurrencyRegisterController : Controller
    {
        private RateEntityModel rateDB = new RateEntityModel();
        private RegisterEntityModel db = new RegisterEntityModel();

        // GET: CurrencyRegister
        public ActionResult Index(string sortType="ascending")
        {
            ViewBag.sortType = sortType;
            if (sortType == "descending")
            {
                return View(db.CurrencyRegisters.OrderByDescending(item => item.OrderNum).ToList());
            }
            return View(db.CurrencyRegisters.OrderBy(item => item.OrderNum).ToList());
        }

        // GET: CurrencyRegister/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CurrencyRegister/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CurrencyCode,CurrencyName,CurrencyLatinName,OrderNum")] CurrencyRegister currencyRegister)
        {
            // Make sure that no characters are unicode
            if (currencyRegister.CurrencyCode.Any(c => c > 127) || currencyRegister.CurrencyLatinName.Any(c => c > 127))
            {
                return View(currencyRegister);
            }
            currencyRegister.CurrencyCode = currencyRegister.CurrencyCode.ToUpper();
            if(db.CurrencyRegisters.Find(currencyRegister.CurrencyCode) != null)
            {
                TempData["displayExistsWarning"] = true;
                return RedirectToAction("Edit/" + currencyRegister.CurrencyCode);
            }
            if (ModelState.IsValid)
            {
                db.CurrencyRegisters.Add(currencyRegister);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(currencyRegister);
        }

        // GET: CurrencyRegister/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CurrencyRegister currencyRegister = db.CurrencyRegisters.Find(id);
            if (currencyRegister == null)
            {
                return HttpNotFound();
            }
            ViewBag.displayExistsWarning = false;
            if (TempData.ContainsKey("displayExistsWarning"))
            {
                ViewBag.displayExistsWarning = TempData["displayExistsWarning"];
            }
            return View(currencyRegister);
        }

        // POST: CurrencyRegister/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CurrencyCode,CurrencyName,CurrencyLatinName,OrderNum")] CurrencyRegister currencyRegister)
        {
            // Make sure that no characters are unicode
            if (currencyRegister.CurrencyLatinName.Any(c => c > 127))
            {
                return View(currencyRegister);
            }
            if (ModelState.IsValid)
            {
                db.Entry(currencyRegister).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(currencyRegister);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
