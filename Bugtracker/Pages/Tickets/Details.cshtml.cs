using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Bugtracker.Data;
using Bugtracker.Models;

namespace Bugtracker.Pages.Tickets
{
    public class DetailsModel : PageModel
    {
        private readonly Bugtracker.Data.BugtrackerContext _context;

        public DetailsModel(Bugtracker.Data.BugtrackerContext context)
        {
            _context = context;
        }

        public Ticket Ticket { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Ticket = await _context.Tickets.FirstOrDefaultAsync(m => m.ID == id);

            if (Ticket == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
