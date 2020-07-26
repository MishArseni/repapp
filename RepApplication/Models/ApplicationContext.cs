using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RepApplication.Models
{
    public class ApplicationContext:DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserProject> userProjects { get; set; }
        public DbSet<Project> Projects { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Role admin = new Role { Id = 1, Name = "Admin" };
            Role employee = new Role { Id = 2, Name = "Employee" };
            User adminUser = new User { UserId = 1, Email = "hiimsenya@gmail.com", Password = "qwe123", RoleId = admin.Id, Name = "Arseni" };

            modelBuilder.Entity<Role>().HasData(new Role[] { admin, employee });
            modelBuilder.Entity<User>().HasData(new User[] { adminUser });

            modelBuilder.Entity<UserProject>().HasKey(t => new { t.UserId, t.ProjectId });

            modelBuilder.Entity<UserProject>().HasOne(pt => pt.User).WithMany(p => p.UserProjects).HasForeignKey(pt => pt.UserId);
            modelBuilder.Entity<UserProject>().HasOne(pt => pt.Projects).WithMany(p => p.UserProjects).HasForeignKey(pt => pt.ProjectId);
        }

    }
}
