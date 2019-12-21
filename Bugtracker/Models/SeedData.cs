using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Bugtracker.Data;

namespace Bugtracker.Models {
    public static class SeedData {
        public static void Initialize(IServiceProvider provider) {
            using (var context = new BugtrackerContext(provider.GetRequiredService<DbContextOptions<BugtrackerContext>>())) {
                
                context.Database.OpenConnection();
                context.Database.ExecuteSqlRaw("PRAGMA foreign_keys=OFF;");
                context.Database.ExecuteSqlRaw("PRAGMA ignore_check_constraints=true;");
                
                seedUsers(context);
                seedTickets(context);
                seedProjects(context);

                context.Database.ExecuteSqlRaw("PRAGMA foreign_keys=ON;");
                context.Database.ExecuteSqlRaw("PRAGMA ignore_check_constraints=false;");
                context.Database.CloseConnection();
            }
        }

        private static void seedProjects(BugtrackerContext context) {
            if (context.Projects.Any()) {
                return;
            }

            seedProjectUsers(context);

            context.Projects.AddRange(
                new Project {
                    Title = "Test Project 1",
                    Description = "A test project",
                    DateCreated = DateTime.Now,
                    AssignedUsers = context.ProjectUsers.Where(u => u.ProjectID == 1).ToList(),
                    Tickets = context.Tickets.Where(t => t.ProjectID == 1).ToList()
                },
                new Project {
                    Title = "Test Project 2",
                    Description = "A test project",
                    DateCreated = DateTime.Now,
                    AssignedUsers = context.ProjectUsers.Where(u => u.ProjectID == 2).ToList(),
                    Tickets = context.Tickets.Where(t => t.ProjectID == 2).ToList()
                },
                new Project {
                    Title = "Test Project 3",
                    Description = "A test project",
                    DateCreated = DateTime.Now,
                    AssignedUsers = context.ProjectUsers.Where(u => u.ProjectID == 3).ToList(),
                    Tickets = context.Tickets.Where(t => t.ProjectID == 3).ToList()
                }
            );

            context.SaveChanges();
        }

        private static void seedProjectUsers(BugtrackerContext context) {
            if (context.ProjectUsers.Any()) {
                return;
            }

            context.ProjectUsers.AddRange(
                new ProjectUser {
                    ProjectID = 1,
                    UserID = 1
                },
                new ProjectUser {
                    ProjectID = 1,
                    UserID = 2
                },
                new ProjectUser {
                    ProjectID = 2,
                    UserID = 1
                },
                new ProjectUser {
                    ProjectID = 2,
                    UserID = 2
                },
                new ProjectUser {
                    ProjectID = 2,
                    UserID = 3
                },
                new ProjectUser {
                    ProjectID = 3,
                    UserID = 4
                },
                new ProjectUser {
                    ProjectID = 3,
                    UserID = 5
                }
            );

            context.SaveChanges();
        }

        private static void seedTickets(BugtrackerContext context) {
            if (context.Tickets.Any()) {
                return;
            }

            seedTicketUsers(context);

            context.Tickets.AddRange(
              new Ticket {
                  Title = "A test ticket",
                  Description = "Stuff is very broken and that is not good",
                  AssignedDevelopers = context.TicketUsers.Where(u => u.TicketID == 1).ToList(),
                  UserID = 1,
                  ProjectID = 1,
                  Priority = Priority.Medium,
                  Status = Status.In_Progress,
                  Type = Type.Bug,
                  DateCreated = DateTime.Now,
                  HistoryIDs = new List<TicketHistory>(),
                  CommentIDs = new List<TicketComment>(),
                  AttachmentIDs = new List<TicketAttachment>()
              },
              new Ticket {
                  Title = "A test ticket",
                  Description = "Stuff is very broken and that is not good",
                  AssignedDevelopers = context.TicketUsers.Where(u => u.TicketID == 2).ToList(),
                  UserID = 1,
                  ProjectID = 2,
                  Priority = Priority.Medium,
                  Status = Status.In_Progress,
                  Type = Type.Bug,
                  DateCreated = DateTime.Now,
                  HistoryIDs = new List<TicketHistory>(),
                  CommentIDs = new List<TicketComment>(),
                  AttachmentIDs = new List<TicketAttachment>()
              },
              new Ticket {
                  Title = "A test ticket",
                  Description = "Stuff is very broken and that is not good",
                  AssignedDevelopers = context.TicketUsers.Where(u => u.TicketID == 3).ToList(),
                  UserID = 4,
                  ProjectID = 3,
                  Priority = Priority.Medium,
                  Status = Status.In_Progress,
                  Type = Type.Bug,
                  DateCreated = DateTime.Now,
                  HistoryIDs = new List<TicketHistory>(),
                  CommentIDs = new List<TicketComment>(),
                  AttachmentIDs = new List<TicketAttachment>()
              },
              new Ticket {
                  Title = "A test ticket",
                  Description = "Stuff is very broken and that is not good",
                  AssignedDevelopers = context.TicketUsers.Where(u => u.TicketID == 4).ToList(),
                  UserID = 2,
                  ProjectID = 1,
                  Priority = Priority.Medium,
                  Status = Status.In_Progress,
                  Type = Type.Bug,
                  DateCreated = DateTime.Now,
                  HistoryIDs = new List<TicketHistory>(),
                  CommentIDs = new List<TicketComment>(),
                  AttachmentIDs = new List<TicketAttachment>()
              },
              new Ticket {
                  Title = "A test ticket",
                  Description = "Stuff is very broken and that is not good",
                  AssignedDevelopers = context.TicketUsers.Where(u => u.TicketID == 5).ToList(),
                  UserID = 2,
                  ProjectID = 1,
                  Priority = Priority.Medium,
                  Status = Status.In_Progress,
                  Type = Type.Bug,
                  DateCreated = DateTime.Now,
                  HistoryIDs = new List<TicketHistory>(),
                  CommentIDs = new List<TicketComment>(),
                  AttachmentIDs = new List<TicketAttachment>()
              }
            );

            context.SaveChanges();
        }

        private static void seedTicketUsers(BugtrackerContext context) {
            if (context.TicketUsers.Any()) {
                return;
            }

            context.TicketUsers.AddRange(
                new TicketUser {
                    TicketID = 1,
                    UserID = 1
                },
                new TicketUser {
                    TicketID = 1,
                    UserID = 2
                },
                new TicketUser {
                    TicketID = 2,
                    UserID = 1
                },
                new TicketUser {
                    TicketID = 2,
                    UserID = 2
                },
                new TicketUser {
                    TicketID = 2,
                    UserID = 3
                },
                new TicketUser {
                    TicketID = 3,
                    UserID = 4
                },
                new TicketUser {
                    TicketID = 3,
                    UserID = 5
                },
                new TicketUser {
                    TicketID = 4,
                    UserID = 2
                },
                new TicketUser {
                    TicketID = 4,
                    UserID = 5
                },
                new TicketUser {
                    TicketID = 5,
                    UserID = 1
                },
                new TicketUser {
                    TicketID = 5,
                    UserID = 3
                }
            );

            context.SaveChanges();
        }

        private static void seedUsers(BugtrackerContext context) {
            if (context.TrackerUsers.Any()) {
                return;
            }

            context.TrackerUsers.AddRange(
                new TrackerUser {
                    Name = "Admin 1",
                    Role = Role.Admin
                },
                new TrackerUser {
                    Name = "Project Manager 1",
                    Role = Role.ProjectManager
                },
                new TrackerUser {
                    Name = "Developer 1",
                    Role = Role.Developer
                },
                new TrackerUser {
                    Name = "QA Tester 1",
                    Role = Role.Tester
                },
                new TrackerUser {
                    Name = "James Wolff",
                    Role = Role.Admin
                }
            );

            context.SaveChanges();
        }
    }
}