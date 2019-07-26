using Microsoft.EntityFrameworkCore;
using System;

namespace SuportAPI.Data
{
    public class BaseContext : DbContext
    {
        public BaseContext(DbContextOptions<BaseContext> options) : base(options) { }

        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Comments> Comments { get; set; }
        public DbSet<TicketUser> TicketUser { get; set; }
    }
}
