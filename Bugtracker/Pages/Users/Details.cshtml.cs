using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Bugtracker.Data;
using Bugtracker.Models;

namespace Bugtracker.Pages.Users
{
    public class DetailsModel : PageModel
    {
        private readonly Bugtracker.Data.BugtrackerContext _context;

        public DetailsModel(Bugtracker.Data.BugtrackerContext context)
        {
            _context = context;
        }

        public TrackerUser TrackerUser { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TrackerUser = await _context.TrackerUsers.FirstOrDefaultAsync(m => m.ID == id);

            if (TrackerUser == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
