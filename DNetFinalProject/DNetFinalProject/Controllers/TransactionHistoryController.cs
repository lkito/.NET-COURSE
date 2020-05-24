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
    public class TransactionHistoryController : Controller
    {
        private TransactionEntityModel db = new TransactionEntityModel();

        // GET: TransactionHistory
        public ActionResult Index()
        {
            return View(db.TransactionHistories.ToList());
        }

        // GET: TransactionHistory/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TransactionHistory transactionHistory = db.TransactionHistories.Find(id);
            if (transactionHistory == null)
            {
                return HttpNotFound();
            }
            return View(transactionHistory);
        }

        // GET: TransactionHistory/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TransactionHistory/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,IncomingCurrencyCode,OutgoingCurrencyCode,IncomingAmount,OutgoingAmount,TransactionDate,Comment")] TransactionHistory transactionHistory)
        {
            if (ModelState.IsValid)
            {
                db.TransactionHistories.Add(transactionHistory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(transactionHistory);
        }

        // GET: TransactionHistory/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TransactionHistory transactionHistory = db.TransactionHistories.Find(id);
            if (transactionHistory == null)
            {
                return HttpNotFound();
            }
            return View(transactionHistory);
        }

        // POST: TransactionHistory/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,IncomingCurrencyCode,OutgoingCurrencyCode,IncomingAmount,OutgoingAmount,TransactionDate,Comment")] TransactionHistory transactionHistory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(transactionHistory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(transactionHistory);
        }

        // GET: TransactionHistory/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TransactionHistory transactionHistory = db.TransactionHistories.Find(id);
            if (transactionHistory == null)
            {
                return HttpNotFound();
            }
            return View(transactionHistory);
        }

        // POST: TransactionHistory/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TransactionHistory transactionHistory = db.TransactionHistories.Find(id);
            db.TransactionHistories.Remove(transactionHistory);
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
