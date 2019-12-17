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
    public class IndexModel : PageModel
    {
        private readonly Bugtracker.Data.BugtrackerContext _context;

        public IndexModel(Bugtracker.Data.BugtrackerContext context)
        {
            _context = context;
        }

        public IList<TrackerUser> TrackerUser { get;set; }

        public async Task OnGetAsync()
        {
            TrackerUser = await _context.TrackerUsers.ToListAsync();
        }
    }
}
