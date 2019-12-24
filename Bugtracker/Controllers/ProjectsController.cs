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
    public class ProjectsController : Controller
    {
        private readonly BugtrackerContext _context;

        public ProjectsController(BugtrackerContext context)
        {
            _context = context;
        }

        // GET: Projects
        public async Task<IActionResult> Index()
        {
            return View(await _context.Projects.ToListAsync());
        }

        // GET: Projects/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var project = await _context.Projects
                .FirstOrDefaultAsync(m => m.ID == id);
            if (project == null)
            {
                return NotFound();
            }

            return View(project);
        }

        // GET: Projects/Create
        public IActionResult Create()
        {
            ViewBag.Users = new MultiSelectList(_context.TrackerUsers.Select(u => new {
                Name = u.Name,
                ID = u.ID
            }).ToList(), "ID", "Name");
            ViewBag.AssignedUsers = new MultiSelectList(new List<Tuple<string, int>>().Select(t => new {
                Name = t.Item1,
                ID = t.Item2
            }).ToList(), "ID", "Name");
            return View();
        }

        // POST: Projects/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Title,Description")] Project project, int[] SelectedUsers)
        {
            if (ModelState.IsValid)
            {
                project.DateCreated = DateTime.Now;
                if (project.AssignedUsers == null) {
                    project.AssignedUsers = new List<ProjectUser>();
                }
                foreach(int i in SelectedUsers) {
                    TrackerUser user = await _context.TrackerUsers.FirstOrDefaultAsync(u => u.ID == i);
                    int pID = (int)NextProjectID() + 1;
                    ProjectUser pUser = new ProjectUser {
                        ProjectID = pID,
                        UserID = user.ID
                    };
                    System.Diagnostics.Debug.WriteLine(pUser.ProjectID);
                    System.Diagnostics.Debug.WriteLine(pUser.UserID);
                    if (!project.AssignedUsers.Contains(pUser)) {
                        System.Diagnostics.Debug.WriteLine("Adding User");
                        project.AssignedUsers.Add(pUser);
                    }
                }
                _context.Add(project);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(project);
        }

        // GET: Projects/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var project = await _context.Projects.FindAsync(id);
            if (project == null)
            {
                return NotFound();
            }
            ViewBag.Users = new MultiSelectList(_context.TrackerUsers.Select(u => new {
                Name = u.Name,
                ID = u.ID
            }).ToList(), "ID", "Name");
            ViewBag.AssignedUsers = new MultiSelectList(project.AssignedUsers.Select(u => new {
                Name = _context.TrackerUsers.FirstOrDefault(t => t.ID == u.UserID).Name,
                ID = u.UserID
            }).ToList(), "ID", "Name");
            return View();
        }

        // POST: Projects/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Title,Description")] Project project, int[] SelectedUsers)
        {
            if (id != project.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                if (project.AssignedUsers == null) {
                    project.AssignedUsers = new List<ProjectUser>();
                }
                foreach(int i in SelectedUsers) {
                    TrackerUser user = await _context.TrackerUsers.FirstOrDefaultAsync(u => u.ID == i);
                    int pID = (int)NextProjectID() + 1;
                    ProjectUser pUser = new ProjectUser {
                        ProjectID = pID,
                        UserID = user.ID
                    };
                    System.Diagnostics.Debug.WriteLine(pUser.ProjectID);
                    System.Diagnostics.Debug.WriteLine(pUser.UserID);
                    if (!project.AssignedUsers.Contains(pUser)) {
                        System.Diagnostics.Debug.WriteLine("Adding User");
                        project.AssignedUsers.Add(pUser);
                    }
                }
                try
                {
                    _context.Update(project);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProjectExists(project.ID))
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
            return View(project);
        }

        // GET: Projects/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var project = await _context.Projects
                .FirstOrDefaultAsync(m => m.ID == id);
            if (project == null)
            {
                return NotFound();
            }

            return View(project);
        }

        // POST: Projects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var project = await _context.Projects.FindAsync(id);
            _context.Projects.Remove(project);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProjectExists(int id)
        {
            return _context.Projects.Any(e => e.ID == id);
        }

        private long NextProjectID() {
            using(var command = _context.Database.GetDbConnection().CreateCommand()) {
                command.CommandText = "SELECT * FROM SQLITE_SEQUENCE WHERE name = 'Projects'";
                _context.Database.OpenConnection();
                using (var result = command.ExecuteReader()) {
                    while (result.Read()) {
                        return (long)result.GetValue(1) + 1;
                    }
                }
            }
            return 0;
        }
    }
}
