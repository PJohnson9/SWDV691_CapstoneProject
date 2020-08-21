using System;
using Microsoft.EntityFrameworkCore;
using MileageTracker.Models;

namespace MileageTracker.Data
{
    public class MTContext : DbContext
    {
        public MTContext(DbContextOptions<MTContext> options)
            : base(options)
        {

        }

        public DbSet<Client> Client { get; set; }
        public DbSet<Project> Project { get; set; }
        public DbSet<Expense> Expense { get; set; }
        //public DbSet<Trip> Trip { get; set; }
    }
}
