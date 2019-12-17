using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Bugtracker.Data;
using Bugtracker.Models;

namespace Bugtracker.Pages.Projects
{
    public class DeleteModel : PageModel
    {
        private readonly Bugtracker.Data.BugtrackerContext _context;

        public DeleteModel(Bugtracker.Data.BugtrackerContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Project Project { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Project = await _context.Projects.FirstOrDefaultAsync(m => m.ID == id);

            if (Project == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Project = await _context.Projects.FindAsync(id);
            List<ProjectUser> ProjectUsers = await _context.ProjectUsers.ToListAsync();

            if (Project != null)
            {
                _context.Projects.Remove(Project);
                foreach(ProjectUser user in ProjectUsers) {
                    if (user.Project != null && user.Project.ID == Project.ID) {
                        _context.ProjectUsers.Remove(user);
                    }
                }
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
