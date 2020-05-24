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
        private RateEntityModel rateDB = new RateEntityModel();
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
            // Get every rated currency code
            ViewBag.existingCodes = new SelectList(rateDB.CurrencyRates.Select(entry => entry.CurrencyCode).ToList());
            return View();
        }

        // POST: TransactionHistory/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,IncomingCurrencyCode,OutgoingCurrencyCode,IncomingAmount,Comment")] TransactionHistory transactionHistory)
        {
            ViewBag.existingCodes = new SelectList(rateDB.CurrencyRates.Select(entry => entry.CurrencyCode).ToList());
            if (transactionHistory.Comment == null) transactionHistory.Comment = "";
            transactionHistory.OutgoingAmount = (int)((decimal)transactionHistory.IncomingAmount
                * rateDB.CurrencyRates.First(entry => entry.CurrencyCode == transactionHistory.IncomingCurrencyCode).SellRateGEL 
                / rateDB.CurrencyRates.First(entry => entry.CurrencyCode == transactionHistory.OutgoingCurrencyCode).BuyRateGEL);
            transactionHistory.TransactionDate = DateTime.Now;
            var bla = transactionHistory;
            if (ModelState.IsValid)
            {
                db.TransactionHistories.Add(transactionHistory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(transactionHistory);
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
