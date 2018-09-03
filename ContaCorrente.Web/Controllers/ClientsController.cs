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
    public class ClientsController : Controller
    {
        private BaseService<Client> _baseService = new BaseService<Client>("https://localhost:44300/api/clients/");
        
        // GET: Clients
        public async Task<ActionResult> Index()
        {
            return View(await _baseService.Get());
        }
        
        // GET: Clients/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            return View(await _baseService.Get(Convert.ToInt32(id)));
        }

        // GET: Clients/Create
        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Edit()
        {
            return View();
        }

        // POST: Clients/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Name")] Client client)
        {
            if (ModelState.IsValid)
            {
                await _baseService.Post(client);
                return RedirectToAction("Index");
            }

            return View(client);
        }
        
        // POST: Clients/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Name")] Client client)
        {
            if (ModelState.IsValid)
            {
                await _baseService.Put(client);
                return RedirectToAction("Index");
            }

            return View(client);
        }

        // GET: Clients/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
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
