using Financas.Data;
using Financas.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Financas.Controllers
{
    public class SubGroupsController : Controller
    {
        private readonly FinancasContext _context;

        public SubGroupsController(FinancasContext context)
        {
            _context = context;
        }

        // GET: SubGroups
        public async Task<IActionResult> Index()
        {
            return View(await _context.SubGroup.ToListAsync());
        }

        // GET: SubGroups/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subGroup = await _context.SubGroup
                .FirstOrDefaultAsync(m => m.Id == id);
            if (subGroup == null)
            {
                return NotFound();
            }

            return View(subGroup);
        }

        // GET: SubGroups/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SubGroups/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("GroupId,Id,Description")] SubGroup subGroup)
        {
            if (ModelState.IsValid)
            {
                subGroup.Id = Guid.NewGuid();
                _context.Add(subGroup);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(subGroup);
        }

        // GET: SubGroups/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subGroup = await _context.SubGroup.FindAsync(id);
            if (subGroup == null)
            {
                return NotFound();
            }
            return View(subGroup);
        }

        // POST: SubGroups/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("GroupId,Id,Description")] SubGroup subGroup)
        {
            if (id != subGroup.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(subGroup);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SubGroupExists(subGroup.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(subGroup);
        }

        // GET: SubGroups/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subGroup = await _context.SubGroup
                .FirstOrDefaultAsync(m => m.Id == id);
            if (subGroup == null)
            {
                return NotFound();
            }

            return View(subGroup);
        }

        // POST: SubGroups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var subGroup = await _context.SubGroup.FindAsync(id);
            _context.SubGroup.Remove(subGroup);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SubGroupExists(Guid id)
        {
            return _context.SubGroup.Any(e => e.Id == id);
        }
    }
}
