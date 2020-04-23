using Financas.Models;
using Financas.Services;
using Financas.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Financas.Controllers
{
    public class TransactionsController : Controller
    {
        private readonly TransactionService _service;
        private readonly List<SubGroup> _subGroups;
        private readonly List<Account> _accounts;

        public TransactionsController(TransactionService service, SubGroupService subGroupService, AccountService accountService)
        {
            _service = service;
            _subGroups = subGroupService.Get();
            _accounts = accountService.Get();
        }

        // GET: Transactions
        public ActionResult<List<TransactionViewModel>> Index()
        {
            var items = _service.Get();

            return View(items.Select(a => new TransactionViewModel(a, _accounts, _subGroups)));
        }

        // GET: Transactions/Details/5
        public ActionResult<TransactionViewModel> Details(string id)
        {
            var item = _service.Get(id);
            if (item == null)
            {
                return NotFound();
            }

            return View(new TransactionViewModel(item, _accounts, _subGroups));
        }

        // GET: Transactions/Create
        public ActionResult<TransactionViewModel> Create()
        {
            return View(new TransactionViewModel(new Transaction(), _accounts, _subGroups));
        }

        // POST: Transactions/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult<TransactionViewModel> Create(TransactionViewModel transaction)
        {
            var item = new Transaction 
            { 
                Description = transaction.Description, 
                AccountId = transaction.Account.Id,
                SubGroupId = transaction.SubGroup.Id,
                CreateOn = DateTime.Now,
                PaymentOn = DateTime.MinValue,
                Status = Models.Enum.TransactionStatus.Pending,
                Type = transaction.Type,
                Value = transaction.Value
            };

            if (ModelState.IsValid)
            {
                _service.Create(item);
                return RedirectToAction(nameof(Index));
            }
            return View(item);
        }

        // GET: Transactions/Edit/5
        public ActionResult<TransactionViewModel> Edit(string id)
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

            return View(new TransactionViewModel(item, _accounts, _subGroups));
        }

        // POST: Transactions/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult<TransactionViewModel> Edit(string id, TransactionViewModel transaction)
        {
            var item = _service.Get(id);
            if (item == null)
            {
                return NotFound();
            }

            item.Description = transaction.Description;
            item.AccountId = transaction.Account.Id;
            item.SubGroupId = transaction.SubGroup.Id;
            item.CreateOn = transaction.CreateOn;
            item.PaymentOn = transaction.PaymentOn;
            item.Status = transaction.Status;
            item.Type = transaction.Type;
            item.Value = transaction.Value;

            _service.Update(id, item);
            return RedirectToAction(nameof(Index));
        }

        // GET: Transactions/Delete/5
        public ActionResult<TransactionViewModel> Delete(string id)
        {
            var item = _service.Get(id);
            if (item == null)
            {
                return NotFound();
            }

            return View(new TransactionViewModel(item, _accounts, _subGroups));
        }

        // POST: Transactions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult<TransactionViewModel> DeleteConfirmed(string id)
        {
            var item = _service.Get(id);
            _service.Remove(item);
            return RedirectToAction(nameof(Index));
        }
    }
}
