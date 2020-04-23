using Financas.Models;
using Financas.Services;
using Financas.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Financas.Controllers
{
    public class SubGroupsController : Controller
    {
        private readonly SubGroupService _service;
        private readonly List<Group> _groups;

        public SubGroupsController(SubGroupService service, GroupService groupService)
        {
            _service = service;
            _groups = groupService.Get();
        }

        // GET: SubGroups
        public ActionResult<List<SubGroupViewModel>> Index()
        {
            var items = _service.Get();

            return View(items.Select(a => new SubGroupViewModel(a, _groups)));
        }

        // GET: Groups/Details/5
        public ActionResult<SubGroupViewModel> Details(string id)
        {
            var item = _service.Get(id);
            if (item == null)
            {
                return NotFound();
            }

            return View(new SubGroupViewModel(item, _groups));
        }

        // GET: SubGroups/Create
        public ActionResult<SubGroupViewModel> Create()
        {
            return View(new SubGroupViewModel(new SubGroup(), _groups));
        }

        // POST: SubGroups/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult<SubGroupViewModel> Create(SubGroupViewModel subGroup)
        {
            var item = new SubGroup { Description = subGroup.Description, GroupId = subGroup.Group.Id };
            if (ModelState.IsValid)
            {
                _service.Create(item);
                return RedirectToAction(nameof(Index));
            }
            return View(item);
        }

        // GET: SubGroups/Edit/5
        public ActionResult<SubGroupViewModel> Edit(string id)
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

            return View(new SubGroupViewModel(item, _groups));
        }

        // POST: SubGroups/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult<SubGroupViewModel> Edit(string id, SubGroupViewModel subGroup)
        {
            var item = _service.Get(id);
            if (item == null)
            {
                return NotFound();
            }

            item.Description = subGroup.Description;
            item.GroupId = subGroup.Group.Id;
            _service.Update(id, item);
            return RedirectToAction(nameof(Index));
        }

        // GET: SubGroups/Delete/5
        public ActionResult<SubGroupViewModel> Delete(string id)
        {
            var item = _service.Get(id);
            if (item == null)
            {
                return NotFound();
            }

            return View(new SubGroupViewModel(item, _groups));
        }

        // POST: SubGroups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult<SubGroupViewModel> DeleteConfirmed(string id)
        {
            var item = _service.Get(id);
            _service.Remove(item);
            return RedirectToAction(nameof(Index));
        }
    }
}
