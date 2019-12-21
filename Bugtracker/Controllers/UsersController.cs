using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Bugtracker.Data;
using Bugtracker.Models;

namespace Bugtracker.Controllers
{
    public class UsersController : Controller
    {
        private readonly BugtrackerContext _context;

        public UsersController(BugtrackerContext context)
        {
            _context = context;
        }

        // GET: Users
        public async Task<IActionResult> Index()
        {
            return View(await _context.TrackerUsers.ToListAsync());
        }

        // GET: Users/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trackerUser = await _context.TrackerUsers
                .FirstOrDefaultAsync(m => m.ID == id);
            if (trackerUser == null)
            {
                return NotFound();
            }

            return View(trackerUser);
        }

        // GET: Users/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,Role")] TrackerUser trackerUser)
        {
            if (ModelState.IsValid)
            {
                _context.Add(trackerUser);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(trackerUser);
        }

        // GET: Users/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trackerUser = await _context.TrackerUsers.FindAsync(id);
            if (trackerUser == null)
            {
                return NotFound();
            }
            return View(trackerUser);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,Role")] TrackerUser trackerUser)
        {
            if (id != trackerUser.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(trackerUser);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TrackerUserExists(trackerUser.ID))
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
            return View(trackerUser);
        }

        // GET: Users/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trackerUser = await _context.TrackerUsers
                .FirstOrDefaultAsync(m => m.ID == id);
            if (trackerUser == null)
            {
                return NotFound();
            }

            return View(trackerUser);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var trackerUser = await _context.TrackerUsers.FindAsync(id);
            _context.TrackerUsers.Remove(trackerUser);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TrackerUserExists(int id)
        {
            return _context.TrackerUsers.Any(e => e.ID == id);
        }
    }
}
