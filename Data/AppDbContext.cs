using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace pr12_vUser.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<InterestGroup> InterestGroups { get; set; }
        public DbSet<UserInterestGroup> UserInterestGroups { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost;Database=UsersDB;TrustServerCertificate=True;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasOne(u => u.UserProfile)
                .WithOne(up => up.User)
                .HasForeignKey<UserProfile>(up => up.UserId);

            modelBuilder.Entity<Role>()
                .HasMany(r => r.Users)
                .WithOne(u => u.Role)
                .HasForeignKey(u => u.RoleId);

            modelBuilder.Entity<UserInterestGroup>()
                .HasKey(usg => new { usg.UserId, usg.InterestGroupId });

            modelBuilder.Entity<UserInterestGroup>()
                .HasOne(uig => uig.User)
                .WithMany(u => u.UserInterestGroups)
                .HasForeignKey(uig => uig.UserId);

            modelBuilder.Entity<UserInterestGroup>()
                .HasOne(uig => uig.InterestGroup)
                .WithMany(u => u.UserInterestGroups)
                .HasForeignKey(uig => uig.InterestGroupId);
        }
    }
}
