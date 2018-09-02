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
    public class AccountsController : Controller
    {
        private BaseService<Account> _baseService = new BaseService<Account>("https://localhost:44300/api/accounts/");
        private BaseService<Client> _baseServiceClient = new BaseService<Client>("https://localhost:44300/api/clients/");

        // GET: Accounts
        public async Task<ActionResult> Index()
        {
            return View(await _baseService.Get());
        }

        // GET: Accounts/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            ViewBag.ClientId= new SelectList(await _baseServiceClient.Get(), "Id", "Name");
            return View(await _baseService.Get(Convert.ToInt32(id)));
        }

        // GET: Accounts/Create
        public async Task<ActionResult> Create()
        {
            ViewBag.ClientId= new SelectList(await _baseServiceClient.Get(), "Id", "Name");
            return View();
        }

        // POST: Accounts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,AccountCode,CurrentBalance,ClientId")] Account account)
        {
            if (ModelState.IsValid)
            {
                await _baseService.Post(account);
                return RedirectToAction("Index");
            }

            ViewBag.ClientId= new SelectList(await _baseServiceClient.Get(), "Id", "Name");
            return View(account);
        }

        // POST: Accounts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,AccountCode,CurrentBalance,ClientId")] Account account)
        {
            if (ModelState.IsValid)
            {
                await _baseService.Put(account);
                return RedirectToAction("Index");
            }

            ViewBag.ClientId= new SelectList(await _baseServiceClient.Get(), "Id", "Name");
            return View(account);
        }

        // GET: Accounts/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            ViewBag.ClientId= new SelectList(await _baseServiceClient.Get(), "Id", "Name");
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

