using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Bugtracker.Data;
using Bugtracker.Models;

namespace Bugtracker.Pages.Users
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
            return Page();
        }

        [BindProperty]
        public TrackerUser TrackerUser { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.TrackerUsers.Add(TrackerUser);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
