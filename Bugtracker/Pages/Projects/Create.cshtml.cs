using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Bugtracker.Data;
using Bugtracker.Models;

namespace Bugtracker.Pages.Projects
{
    public class CreateModel : PageModel
    {
        private readonly Bugtracker.Data.BugtrackerContext _context;

        public CreateModel(Bugtracker.Data.BugtrackerContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            var trackerUsers = _context.TrackerUsers.Select(t => new {
                ID = t.ID,
                Name = t.Name,
                Role = t.Role
            }).ToList();
            Users = new MultiSelectList(trackerUsers, "ID", "Name");

            return Page();
        }

        [BindProperty]
        public Project Project { get; set; }
        public MultiSelectList Users { get; set; }
        public int[] AssignedUsers { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int[] AssignedUsers)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            ProjectUser pUser = new ProjectUser();
            List<TrackerUser> tUsers = _context.TrackerUsers.ToList();
            if (Project.AssignedUsers == null) {
                Project.AssignedUsers = new List<ProjectUser>();
            }
            foreach(int user in AssignedUsers) {
                pUser.Project = Project;
                Console.Out.Write("\n\n\n" + user + "\n\n\n");
                pUser.User = tUsers.ElementAt(user-1);
                Project.AssignedUsers.Add(pUser);
            }

            _context.Projects.Add(Project);

            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
