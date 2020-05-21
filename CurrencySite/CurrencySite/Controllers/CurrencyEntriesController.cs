using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CurrencySite.Models;

namespace CurrencySite.Controllers
{
    public class CurrencyEntriesController : Controller
    {
        private Model1 db = new Model1();

        // GET: CurrencyEntries
        public ActionResult Index()
        {
            return View(db.CurrencyEntries.Where(e => e.Enabled).ToList());
        }

        // GET: CurrencyEntries/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CurrencyEntries/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,FromCurrency,ToCurrency,Rate")] CurrencyEntry currencyEntry)
        {
            if (ModelState.IsValid)
            {
                CurrencyEntry deleted = db.CurrencyEntries.Where(e => e.FromCurrency == currencyEntry.FromCurrency
                    && e.ToCurrency == currencyEntry.ToCurrency).FirstOrDefault();
                if(deleted != null) // Do an update if old entry with same currencies was "deleted"
                {
                    deleted.Enabled = true;
                    deleted.DateUpdated = DateTime.Now;
                    deleted.Rate = currencyEntry.Rate;
                } else
                {
                    currencyEntry.Enabled = true;
                    currencyEntry.DateCreated = DateTime.Now;
                    currencyEntry.DateUpdated = DateTime.Now;
                    db.CurrencyEntries.Add(currencyEntry);

                }
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(currencyEntry);
        }

        // GET: CurrencyEntries/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CurrencyEntry currencyEntry = db.CurrencyEntries.Find(id);
            if (currencyEntry == null)
            {
                return HttpNotFound();
            }
            return View(currencyEntry);
        }

        // POST: CurrencyEntries/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,FromCurrency,ToCurrency,Rate,DateCreated,DateUpdated")] CurrencyEntry currencyEntry)
        {
            if (ModelState.IsValid)
            {
                currencyEntry.Enabled = true;
                currencyEntry.DateUpdated = DateTime.Now;
                
                db.Entry(currencyEntry).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(currencyEntry);
        }

        // GET: CurrencyEntries/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CurrencyEntry currencyEntry = db.CurrencyEntries.Find(id);
            if (currencyEntry == null)
            {
                return HttpNotFound();
            }
            return View(currencyEntry);
        }

        // POST: CurrencyEntries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CurrencyEntry currencyEntry = db.CurrencyEntries.Find(id);
            currencyEntry.Enabled = false;
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
