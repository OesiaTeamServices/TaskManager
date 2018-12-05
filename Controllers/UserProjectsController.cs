using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Oesia.Data;
using Oesia.Models;

namespace Oesia.Controllers
{
    public class UserProjectsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UserProjectsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: UserProjects
        public async Task<IActionResult> Index()
        {
            return View(await _context.UserProject.ToListAsync());
        }

        // GET: UserProjects/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userProject = await _context.UserProject
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userProject == null)
            {
                return NotFound();
            }

            return View(userProject);
        }

        // GET: UserProjects/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: UserProjects/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id")] UserProject userProject)
        {
            if (ModelState.IsValid)
            {
                _context.Add(userProject);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(userProject);
        }

        // GET: UserProjects/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userProject = await _context.UserProject.FindAsync(id);
            if (userProject == null)
            {
                return NotFound();
            }
            return View(userProject);
        }

        // POST: UserProjects/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id")] UserProject userProject)
        {
            if (id != userProject.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userProject);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserProjectExists(userProject.Id))
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
            return View(userProject);
        }

        // GET: UserProjects/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userProject = await _context.UserProject
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userProject == null)
            {
                return NotFound();
            }

            return View(userProject);
        }

        // POST: UserProjects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var userProject = await _context.UserProject.FindAsync(id);
            _context.UserProject.Remove(userProject);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserProjectExists(long id)
        {
            return _context.UserProject.Any(e => e.Id == id);
        }
    }
}
