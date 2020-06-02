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
    public class CurrencyRatesController : Controller
    {
        private RateEntityModel db = new RateEntityModel();
        private RegisterEntityModel registerDB = new RegisterEntityModel();

        // GET: CurrencyRates
        public ActionResult Index()
        {
            return View(db.CurrencyRates.ToList());
        }

        // GET: CurrencyRate
        public JsonResult GetCurrencyRate(string currencyCode)
        {
            CurrencyRate rate = db.CurrencyRates.FirstOrDefault(entry => entry.CurrencyCode == currencyCode);
            if (rate == null) {
                rate = new CurrencyRate();
            }
            return Json(new { rate.BuyRateGEL, rate.SellRateGEL }, JsonRequestBehavior.AllowGet);
        }

        // GET: CurrencyRates/Create
        public ActionResult Create(int id = -1)
        {
            // This is needed for when user clicks "edit" button
            CurrencyRate cur = db.CurrencyRates.Find(id); // Get entry, if id was passed

            // Get every currency code
            ViewBag.existingCodes = new SelectList((from a in registerDB.CurrencyRegisters
                                                    orderby a.OrderNum
                                                    select a.CurrencyCode).ToList());
            return View(cur);
        }

        // POST: CurrencyRates/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,CurrencyCode,BuyRateGEL,SellRateGEL")] CurrencyRate currencyRate)
        {
            CurrencyRate cr = db.CurrencyRates.FirstOrDefault(entry => entry.CurrencyCode == currencyRate.CurrencyCode);
            if (ModelState.IsValid)
            {
                if (cr != null)
                {
                    cr.BuyRateGEL = currencyRate.BuyRateGEL;
                    cr.SellRateGEL = currencyRate.SellRateGEL;
                    db.Entry(cr).State = EntityState.Modified;
                } else
                {
                    db.CurrencyRates.Add(currencyRate);
                }
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            // Get every currency code
            ViewBag.existingCodes = new SelectList((from a in registerDB.CurrencyRegisters
                                                    orderby a.OrderNum
                                                    select a.CurrencyCode).ToList());
            return View(currencyRate);
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
