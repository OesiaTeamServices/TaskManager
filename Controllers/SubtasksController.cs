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
using Oesia.Services;

namespace Oesia.Controllers
{
    public class SubtasksController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<AppUser> _userManager;
        private readonly OesiaServices _services;

        public SubtasksController(ApplicationDbContext context, 
                                  UserManager<AppUser> userManager,
                                  OesiaServices services)
        {
            _context = context;
            _userManager = userManager;
            _services = services;
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
        public async Task<IActionResult> Create([Bind("Id,SubtaskId,Description,UserId,EstimatedHours,ElapsedHours,PendingHours,Observations,Status,TaskId,UserId")] Subtask subtask)
        {
            subtask.PendingHours = subtask.EstimatedHours;
            subtask.Status = "At risk";

            AppUser user = new AppUser();
            foreach (AppUser userChoice in _services.GetUsersByRoleDB("Technician"))
            {
                if (userChoice.Id == subtask.UserId) {
                    user = userChoice;
                }
            }

            UserSubtask userSubtask = new UserSubtask
            {
                AppUsers = user,
                Subtasks = subtask
            };

            if (ModelState.IsValid)
            {
                _context.Add(subtask);
                _context.UserSubtask.Add(userSubtask);
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
        public async Task<IActionResult> Edit(long id, [Bind("Id,SubtaskId,Description,UserId,EstimatedHours,ElapsedHours,PendingHours,Observations,Status,TaskId,UserId")] Subtask subtask )
        {
            AppUser user = new AppUser();
            foreach (AppUser userChoice in _services.GetUsersByRoleDB("Technician"))
            {
                if (userChoice.Id == subtask.UserId)
                {
                    user = userChoice;
                }
            }

            UserSubtask userSubtask = new UserSubtask();
            userSubtask = await _context.UserSubtask.FirstOrDefaultAsync(x => x.AppUsers.Id == user.Id && x.Subtasks.Id == subtask.Id);
            userSubtask.AppUsers = user;
            userSubtask.Subtasks = subtask;

            if (id != subtask.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(subtask);
                    _context.UserSubtask.Update(userSubtask);
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


        //PLAY 
        [HttpPost]
        public async Task<IActionResult> Play(long id)
        {
            //_context.UserSubtask.Single()
            AppUser currentUser = new AppUser();
            UserSubtask userSubtask = new UserSubtask();
            DateTime playtime = DateTime.Now;

            currentUser = await _userManager.GetUserAsync(User);

            userSubtask =  _context.UserSubtask.Single(x=>x.AppUsers.Id == currentUser.Id && x.Subtasks.Id == id);
            userSubtask.PlayTime = playtime;

            _context.UserSubtask.Update(userSubtask);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Subtasks");
        }

        //Pause
        public async Task<IActionResult> Pause(long id)
        {
            AppUser currentUser = new AppUser();
            UserSubtask userSubtask = new UserSubtask();
            DateTime pausetime = DateTime.Now;
            TimeSpan duration;

            currentUser = await _userManager.GetUserAsync(User);

            userSubtask = _context.UserSubtask.Single(x => x.AppUsers.Id == currentUser.Id && x.Subtasks.Id == id);
            userSubtask.PauseTime = pausetime;

            duration = pausetime - userSubtask.PlayTime;
            userSubtask.RecordTime = userSubtask.RecordTime.Add(duration);

            _context.UserSubtask.Update(userSubtask);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Subtasks");
        }


        //STOP

        public async Task<IActionResult> Stop(long id)
        {
            AppUser currentUser = new AppUser();
            UserSubtask userSubtask = new UserSubtask();
            DateTime stoptime = DateTime.Now;
            TimeSpan duration;

            currentUser = await _userManager.GetUserAsync(User);

            userSubtask = _context.UserSubtask.Single(x => x.AppUsers.Id == currentUser.Id && x.Subtasks.Id == id);
            userSubtask.StopTime = stoptime;

            duration = stoptime - userSubtask.PlayTime;
            userSubtask.RecordTime = userSubtask.RecordTime.Add(duration);

            _context.UserSubtask.Update(userSubtask);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Subtasks");
        }
    }
}
