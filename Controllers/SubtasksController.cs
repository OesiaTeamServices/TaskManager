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
    public class SubtasksController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SubtasksController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Subtasks
        public async Task<IActionResult> Index()
        {
            return View(await _context.Subtask.ToListAsync());
        }

        // GET: Subtasks/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subtask = await _context.Subtask
                .FirstOrDefaultAsync(m => m.Id == id);
            if (subtask == null)
            {
                return NotFound();
            }

            return View(subtask);
        }

        // GET: Subtasks/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Subtasks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,SubtaskId,Description,UserId,EstimatedHours,ElapsedHours,PendingHours,Observations,Status")] Subtask subtask)
        {
            if (ModelState.IsValid)
            {
                _context.Add(subtask);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(subtask);
        }

        // GET: Subtasks/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subtask = await _context.Subtask.FindAsync(id);
            if (subtask == null)
            {
                return NotFound();
            }
            return View(subtask);
        }

        // POST: Subtasks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,SubtaskId,Description,UserId,EstimatedHours,ElapsedHours,PendingHours,Observations,Status")] Subtask subtask)
        {
            if (id != subtask.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(subtask);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SubtaskExists(subtask.Id))
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
            return View(subtask);
        }

        // GET: Subtasks/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subtask = await _context.Subtask
                .FirstOrDefaultAsync(m => m.Id == id);
            if (subtask == null)
            {
                return NotFound();
            }

            return View(subtask);
        }

        // POST: Subtasks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var subtask = await _context.Subtask.FindAsync(id);
            _context.Subtask.Remove(subtask);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SubtaskExists(long id)
        {
            return _context.Subtask.Any(e => e.Id == id);
        }
    }
}
