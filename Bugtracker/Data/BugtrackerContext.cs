using Microsoft.EntityFrameworkCore;

namespace Bugtracker.Data {
    public class BugtrackerContext : DbContext {
        public BugtrackerContext (DbContextOptions<BugtrackerContext> options) : base(options) {}

        public DbSet<Bugtracker.Models.Project> Projects { get; set; }
        public DbSet<Bugtracker.Models.ProjectUser> ProjectUsers { get; set; }
        public DbSet<Bugtracker.Models.Ticket> Tickets { get; set; }
        public DbSet<Bugtracker.Models.TicketAttachment> TicketAttachments { get; set; }
        public DbSet<Bugtracker.Models.TicketHistory> TicketHistorys { get; set; }
        public DbSet<Bugtracker.Models.TicketComment> TicketComments { get; set; }
        public DbSet<Bugtracker.Models.TicketUser> TicketUsers { get; set; }
        public DbSet<Bugtracker.Models.TrackerUser> TrackerUsers { get; set; }
    }
}