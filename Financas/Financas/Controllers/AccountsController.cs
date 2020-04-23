using Financas.Models;
using Financas.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Financas.Controllers
{
    public class AccountsController : Controller
    {
        private readonly AccountService _service;

        public AccountsController(AccountService service)
        {
            _service = service;
        }

        // GET: Accounts
        public ActionResult<List<Account>> Index()
        {
            return View(_service.Get());
        }

        // GET: Accounts/Details/5
        public ActionResult<Account> Details(string id)
        {
            var item = _service.Get(id);
            if (item == null)
            {
                return NotFound();
            }

            return View(item);
        }

        // GET: Accounts/Create
        public ActionResult<Account> Create()
        {
            return View();
        }

        // POST: Accounts/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult<Account> Create([Bind("Type,Description,Bank,Agency,Number,Status")] Account item)
        {
            if (ModelState.IsValid)
            {
                _service.Create(item);
                return RedirectToAction(nameof(Index));
            }
            return View(item);
        }

        // GET: Accounts/Edit/5
        public ActionResult<Account> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var item = _service.Get(id);
            if (item == null)
            {
                return NotFound();
            }
            return View(item);
        }

        // POST: Accounts/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult<Account> Edit(string id, [Bind("Id,Type,Description,Bank,Agency,Number,Status")] Account item)
        {
            var itemGet = _service.Get(id);
            if (itemGet == null)
            {
                return NotFound();
            }

            item.Id = id;
            _service.Update(id, item);
            return RedirectToAction(nameof(Index));
        }

        // GET: Accounts/Delete/5
        public ActionResult<Account> Delete(string id)
        {
            var item = _service.Get(id);
            if (item == null)
            {
                return NotFound();
            }
            return View(item);
        }

        // POST: Accounts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult<Account> DeleteConfirmed(string id)
        {
            var item = _service.Get(id);
            _service.Remove(item);
            return RedirectToAction(nameof(Index));
        }
    }
}
