using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Oesia.Data;
using Oesia.Models;
using Oesia.Services;

namespace Oesia.Controllers
{
    [Authorize]
    public class TasksController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<AppUser> _userManager;
        private readonly OesiaServices _services;

        public TasksController(ApplicationDbContext context, 
                               UserManager<AppUser> userManager,
                               OesiaServices services)
        {
            _context = context;
            _userManager = userManager;
            _services = services;
        }

        // GET: Tasks

        public async Task<IActionResult> Index()
        {
            return View(await _context.Task.ToListAsync());
        }

        // GET: Tasks/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var task = await _context.Task
                .FirstOrDefaultAsync(m => m.Id == id);
            if (task == null)
            {
                return NotFound();
            }

            return View(task);
        }

        // GET: Tasks/Create
        [Authorize(Roles = "Project manager,Task manager")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Tasks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Project manager,Task manager")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TaskId,Description,Type,Criticality,Priority,CreateDate,EstimatedStartDate,EstimatedEndDate,RealStartDate,RealEndDate,EstimatedHours,ElapsedHours,PendingHours,Status,SubmoduleId,UserId")] Oesia.Models.Task task)
        {
            task.CreateDate = DateTime.Now;
            task.PendingHours = task.EstimatedHours;
            task.Status = "At risk";

            AppUser user = new AppUser();
            foreach(AppUser item in _services.GetUsersByRoleDB("Task manager")) {
                if(item.Id == task.UserId){
                    user = item;
                }
            }

            // Create new obeject which links AppUsers and Tasks
            UserTask userTask = new UserTask
            {
                AppUsers = user,
                Tasks = task
            };

            if (ModelState.IsValid)
            {
                _context.Add(task);
                _context.UserTask.Add(userTask);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(task);
        }

        // GET: Tasks/Edit/5
        [Authorize(Roles = "Project manager,Task manager")]
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var task = await _context.Task.FindAsync(id);
            if (task == null)
            {
                return NotFound();
            }
            return View(task);
        }

        // POST: Tasks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Project manager,Task manager")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,TaskId,Description,Type,Criticality,Priority,CreateDate,EstimatedStartDate,EstimatedEndDate,RealStartDate,RealEndDate,EstimatedHours,ElapsedHours,PendingHours,Status,SubmoduleId,UserId")] Oesia.Models.Task task )
        {
            AppUser user = new AppUser();
            foreach (AppUser userChoice in _services.GetUsersByRoleDB("Task manager"))
            {
                if (userChoice.Id == task.UserId)
                {
                    user = userChoice;
                }
            }

            UserTask userTask = new UserTask();
            userTask = await _context.UserTask.FirstOrDefaultAsync(x => x.AppUsers.Id == user.Id && x.Tasks.Id == task.Id);
            userTask.AppUsers = user;
            userTask.Tasks = task;

            if (id != task.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(task);
                    _context.UserTask.Update(userTask);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TaskExists(task.Id))
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
            return View(task);
        }

        // GET: Tasks/Delete/5
        [Authorize(Roles = "Project manager,Task manager")]
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var task = await _context.Task
                .FirstOrDefaultAsync(m => m.Id == id);
            if (task == null)
            {
                return NotFound();
            }

            return View(task);
        }

        // POST: Tasks/Delete/5
        [Authorize(Roles = "Project manager,Task manager")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var task = await _context.Task.FindAsync(id);
            _context.Task.Remove(task);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TaskExists(long id)
        {
            return _context.Task.Any(e => e.Id == id);
        }
    }
}
