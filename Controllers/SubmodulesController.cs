using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Oesia.Data;
using Oesia.Models;

namespace Oesia.Controllers
{
    public class SubmodulesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SubmodulesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Submodules
        public async Task<IActionResult> Index()
        {
            return View(await _context.Submodule.ToListAsync());
        }

        // GET: Submodules/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var submodule = await _context.Submodule
                .FirstOrDefaultAsync(m => m.Id == id);
            if (submodule == null)
            {
                return NotFound();
            }

            return View(submodule);
        }

        // GET: Submodules/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Submodules/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,SubmoduleId,Description,EstimatedHours,ElapsedHours,PendingHours,Status,ModuleId")] Submodule submodule)
        {
            submodule.PendingHours = submodule.EstimatedHours;
            submodule.Status = "At risk";

            if (ModelState.IsValid)
            {
                _context.Add(submodule);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(submodule);
        }

        // GET: Submodules/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var submodule = await _context.Submodule.FindAsync(id);
            if (submodule == null)
            {
                return NotFound();
            }
            return View(submodule);
        }

        // POST: Submodules/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,SubmoduleId,Description,EstimatedHours,ElapsedHours,PendingHours,Status")] Submodule submodule)
        {
            if (id != submodule.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(submodule);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SubmoduleExists(submodule.Id))
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
            return View(submodule);
        }

        // GET: Submodules/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var submodule = await _context.Submodule
                .FirstOrDefaultAsync(m => m.Id == id);
            if (submodule == null)
            {
                return NotFound();
            }

            return View(submodule);
        }

        // POST: Submodules/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var submodule = await _context.Submodule.FindAsync(id);
            _context.Submodule.Remove(submodule);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SubmoduleExists(long id)
        {
            return _context.Submodule.Any(e => e.Id == id);
        }
    }
}
