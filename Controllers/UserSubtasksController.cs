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
    public class UserSubtasksController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UserSubtasksController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: UserSubtasks
        public async Task<IActionResult> Index()
        {
            return View(await _context.UserSubtask.ToListAsync());
        }

        // GET: UserSubtasks/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userSubtask = await _context.UserSubtask
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userSubtask == null)
            {
                return NotFound();
            }

            return View(userSubtask);
        }

        // GET: UserSubtasks/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: UserSubtasks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PlayTime,PauseTime,StopTime,RecordTime")] UserSubtask userSubtask)
        {
            if (ModelState.IsValid)
            {
                _context.Add(userSubtask);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(userSubtask);
        }

        // GET: UserSubtasks/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userSubtask = await _context.UserSubtask.FindAsync(id);
            if (userSubtask == null)
            {
                return NotFound();
            }
            return View(userSubtask);
        }

        // POST: UserSubtasks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,PlayTime,PauseTime,StopTime,RecordTime")] UserSubtask userSubtask)
        {
            if (id != userSubtask.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userSubtask);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserSubtaskExists(userSubtask.Id))
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
            return View(userSubtask);
        }

        // GET: UserSubtasks/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userSubtask = await _context.UserSubtask
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userSubtask == null)
            {
                return NotFound();
            }

            return View(userSubtask);
        }

        // POST: UserSubtasks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var userSubtask = await _context.UserSubtask.FindAsync(id);
            _context.UserSubtask.Remove(userSubtask);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserSubtaskExists(long id)
        {
            return _context.UserSubtask.Any(e => e.Id == id);
        }
    }
}
