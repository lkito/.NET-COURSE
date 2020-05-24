﻿using System;
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

        // GET: CurrencyRates/Create
        public ActionResult Create(int id = -1)
        {
            CurrencyRate cur = db.CurrencyRates.Find(id); // Get entry, if id was passed
            // Get every currency code
            ViewBag.existingCodes = new SelectList(registerDB.CurrencyRegisters.Select(entry => entry.CurrencyCode).ToList());
            return View(cur);
        }

        // POST: CurrencyRates/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,CurrencyCode,BuyRateGEL,SellRateGEL")] CurrencyRate currencyRate)
        {
            if (ModelState.IsValid)
            {
                CurrencyRate cr = db.CurrencyRates.FirstOrDefault(entry => entry.CurrencyCode == currencyRate.CurrencyCode);
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

            return View(currencyRate);
        }

        // GET: CurrencyRates/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CurrencyRate currencyRate = db.CurrencyRates.Find(id);
            if (currencyRate == null)
            {
                return HttpNotFound();
            }
            return View(currencyRate);
        }

        // POST: CurrencyRates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CurrencyRate currencyRate = db.CurrencyRates.Find(id);
            db.CurrencyRates.Remove(currencyRate);
            db.SaveChanges();
            return RedirectToAction("Index");
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
