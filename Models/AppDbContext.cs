using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlatheaGazette.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {

        }

        public DbSet<UserModel> Users { get; set; }
        public DbSet<SessionModel> UserSessions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SessionModel>()
                .HasOne(sM => sM.User)
                .WithOne()
                .HasForeignKey<SessionModel>(sM => sM.UserId);
                
        }
    }
}
