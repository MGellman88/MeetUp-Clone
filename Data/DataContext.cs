using Microsoft.EntityFrameworkCore;
using TheBelt.Models;

namespace TheBelt.Data
{
        public class DataContext : DbContext
        {
            public DataContext (DbContextOptions<DataContext> options) : base (options) { }

            public DbSet<User> Users { get; set; }
            public DbSet<Activity> Activities { get; set; }
            public DbSet<Participant> Participants { get; set; }
        }
    
}