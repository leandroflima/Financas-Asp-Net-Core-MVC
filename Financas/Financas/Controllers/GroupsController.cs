using Financas.Models;
using Financas.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Financas.Controllers
{
    public class GroupsController : Controller
    {
        private readonly GroupService _service;

        public GroupsController(GroupService service)
        {
            _service = service;
        }

        // GET: Groups
        public ActionResult<List<Group>> Index()
        {
            return View(_service.Get());
        }

        // GET: Groups/Details/5
        public ActionResult<Group> Details(string id)
        {
            var item = _service.Get(id);
            if (item == null)
            {
                return NotFound();
            }

            return View(item);
        }

        // GET: Accounts/Create
        public ActionResult<Group> Create()
        {
            return View();
        }

        // POST: Groups/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult<Group> Create([Bind("Id,Description")] Group item)
        {
            if (ModelState.IsValid)
            {
                _service.Create(item);
                return RedirectToAction(nameof(Index));
            }
            return View(item);
        }

        // GET: Groups/Edit/5
        public ActionResult<Group> Edit(string id)
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

        // POST: Groups/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult<Group> Edit(string id, [Bind("Id,Description")] Group item)
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

        // GET: Groups/Delete/5
        public ActionResult<Group> Delete(string id)
        {
            var item = _service.Get(id);
            if (item == null)
            {
                return NotFound();
            }
            return View(item);
        }

        // POST: Groups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult<Group> DeleteConfirmed(string id)
        {
            var item = _service.Get(id);
            _service.Remove(item);
            return RedirectToAction(nameof(Index));
        }
    }
}
