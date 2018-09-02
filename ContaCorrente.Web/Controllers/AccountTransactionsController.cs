using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ContaCorrente.Model;
using ContaCorrente.Repository;
using ContaCorrente.Web.Services;

namespace ContaCorrente.Web.Controllers
{
    public class AccountTransactionsController : Controller
    {
        private BaseService<AccountTransaction> _baseService = new BaseService<AccountTransaction>("https://localhost:44300/api/accountTransactions/");
        private BaseService<Account> _baseServiceAccount = new BaseService<Account>("https://localhost:44300/api/accounts/");

        // GET: Accounts
        public async Task<ActionResult> Index()
        {
            return View(await _baseService.Get());
        }

        // GET: AccountTransactions/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            ViewBag.AccountId = new SelectList(await _baseServiceAccount.Get(), "Id", "AccountCode");
            return View(await _baseService.Get(Convert.ToInt32(id)));
        }

        // GET: AccountTransactions/Create
        public async Task<ActionResult> Create()
        {
            ViewBag.AccountId = new SelectList(await _baseServiceAccount.Get(), "Id", "AccountCode");
            return View();
        }

        // POST: AccountTransactions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,TransactionDateTime,TransactionType,TransactionValue,AccountId")] AccountTransaction account)
        {
            if (ModelState.IsValid)
            {
                await _baseService.Post(account);
                return RedirectToAction("Index");
            }

            ViewBag.AccountId = new SelectList(await _baseServiceAccount.Get(), "Id", "AccountCode");
            return View(account);
        }

        // POST: AccountTransactions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        public int AccountId { get; set; }

        public async Task<ActionResult> Edit([Bind(Include = "Id,TransactionDateTime,TransactionType,TransactionValue,AccountId")] AccountTransaction account)
        {
            if (ModelState.IsValid)
            {
                await _baseService.Put(account);
                return RedirectToAction("Index");
            }

            ViewBag.AccountId = new SelectList(await _baseServiceAccount.Get(), "Id", "AccountCode");
            return View(account);
        }

        // GET: AccountTransactions/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            ViewBag.AccountId = new SelectList(await _baseServiceAccount.Get(), "Id", "AccountCode");
            return View(await _baseService.Delete(Convert.ToInt32(id)));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
            }
            base.Dispose(disposing);
        }
    }
}

