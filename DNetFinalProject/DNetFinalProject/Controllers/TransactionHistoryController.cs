using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using DNetFinalProject.Models;

namespace DNetFinalProject.Controllers
{
    public class TransactionHistoryController : Controller
    {
        private RegisterEntityModel regDB = new RegisterEntityModel();
        private RateEntityModel rateDB = new RateEntityModel();
        private TransactionEntityModel db = new TransactionEntityModel();

        // GET: TransactionHistory
        public ActionResult Index(bool displaySuspect = false, string curTime="last month")
        {
            // Pass sort types
            ViewBag.displaySuspect = displaySuspect;
            ViewBag.timeSelect = new SelectList(new List<string> { "all", "last year", "last month", "last week", "last day", "last hour" }, curTime);
            var dbAll = db.TransactionHistories.OrderByDescending(entry => entry.TransactionDate);
            // Sort based on received sort type
            List<TransactionHistory> displayList = null;
            DateTime testDate = DateTime.Now;
            switch (curTime)
            {
                case "last hour":
                    testDate = testDate.AddHours(-1);
                    break;
                case "last day":
                    testDate = testDate.AddDays(-1);
                    break;
                case "last week":
                    testDate = testDate.AddDays(-7);
                    break;
                case "last month":
                    testDate = testDate.AddMonths(-1);
                    break;
                case "last year":
                    testDate = testDate.AddYears(-1);
                    break;
                default:
                    testDate = DateTime.MinValue;
                    break;
            }
            var dbTime = dbAll.Where(entry => DateTime.Compare(entry.TransactionDate, testDate) >= 0);
            displayList = dbTime.ToList();
            if (displaySuspect) // If user asked for suspicious transactions
            {
                // Get rates
                Dictionary<string, decimal> sellRates = rateDB.CurrencyRates.Select(entry => entry)
                    .ToDictionary(item => item.CurrencyCode, item => item.SellRateGEL);
                var tranList = dbTime.ToList();

                // Sort by amount in GEL
                tranList.Sort((x, y) =>(y.IncomingAmount * sellRates[y.IncomingCurrencyCode])
                    .CompareTo(x.IncomingAmount * sellRates[x.IncomingCurrencyCode]));
                displayList = tranList.Take(3).ToList();
            }
            return View(displayList);
        }

        // Get exchange rate by passing currency codes
        public JsonResult GetRateByCode(string incomingCode, string outgoingCode)
        {
            CurrencyRate incRate = rateDB.CurrencyRates.FirstOrDefault(entry => entry.CurrencyCode == incomingCode);
            CurrencyRate outRate = rateDB.CurrencyRates.FirstOrDefault(entry => entry.CurrencyCode == outgoingCode);
            if (incRate == null || outRate == null)
            {
                incRate = new CurrencyRate();
                outRate = new CurrencyRate();
            }
            return Json(new { incRate.BuyRateGEL, outRate.SellRateGEL }, JsonRequestBehavior.AllowGet);
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
            var regList = (from a in regDB.CurrencyRegisters
                           select new { a.CurrencyCode, a.OrderNum }).ToList();
            var rateList = (from a in rateDB.CurrencyRates
                            select a.CurrencyCode).ToList();
            ViewBag.existingCodes = new SelectList((from a in regList
                                                    join b in rateList on a.CurrencyCode equals b
                                                    orderby a.OrderNum
                                                    select a.CurrencyCode).ToList());
            return View();
        }

        // POST: TransactionHistory/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,IncomingCurrencyCode,OutgoingCurrencyCode,IncomingAmount,Comment")] TransactionHistory transactionHistory)
        {
            decimal buyRate = rateDB.CurrencyRates.First(entry => entry.CurrencyCode == transactionHistory.IncomingCurrencyCode).BuyRateGEL;
            decimal sellRate = rateDB.CurrencyRates.First(entry => entry.CurrencyCode == transactionHistory.OutgoingCurrencyCode).SellRateGEL;
            transactionHistory.OutgoingAmount = (int)(transactionHistory.IncomingAmount * buyRate / sellRate);

            // Get codes of rated currencies
            var regList = (from a in regDB.CurrencyRegisters
                           select new { a.CurrencyCode, a.OrderNum }).ToList();
            var rateList = (from a in rateDB.CurrencyRates
                            select a.CurrencyCode).ToList();
            ViewBag.existingCodes = new SelectList((from a in regList
                                                    join b in rateList on a.CurrencyCode equals b
                                                    orderby a.OrderNum
                                                    select a.CurrencyCode).ToList());
            // Make sure that no characters are unicode
            if (transactionHistory.IncomingAmount * sellRate > 3000 && transactionHistory.Comment == null)
            {
                return View(transactionHistory);
            }
            // Add blank comment if it's null
            if (transactionHistory.Comment == null) transactionHistory.Comment = "";
            // Determine outgoing amount based on incoming amount and exchange rate
            transactionHistory.OutgoingAmount = (int)(transactionHistory.IncomingAmount * buyRate / sellRate);
            transactionHistory.TransactionDate = DateTime.Now;
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
