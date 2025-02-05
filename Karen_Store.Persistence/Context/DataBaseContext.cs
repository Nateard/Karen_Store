using Karen_Store.Application.Interfaces.Context;
using Karen_Store.Common.Role;
using Karen_Store.Domain.Entities.Product;
using Karen_Store.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Karen_Store.Persistence.Context
{
    public class DataBaseContext : DbContext, IDatabaseContext
    {
        public DataBaseContext(DbContextOptions options ):base(options)
        {
                
        }
        public DbSet<User> Users {  get; set; }
        public DbSet<Role>Role { get; set; }
        public DbSet<UserInRole>UserInRole { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            SeedData(modelBuilder);
            DataQueryFilter(modelBuilder);
            modelBuilder.Entity<User>().HasIndex(u => u.Email).IsUnique();
        }

        private void SeedData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>().HasData(new Role { Id = 1, Name = nameof(UserRoles.Admin) });
            modelBuilder.Entity<Role>().HasData(new Role { Id = 2, Name = nameof(UserRoles.Operator) });
            modelBuilder.Entity<Role>().HasData(new Role { Id = 3, Name = nameof(UserRoles.Customer) });
            modelBuilder.Entity<Role>().HasData(new Role { Id = 4, Name = nameof(UserRoles.Support) });
        }

        private void DataQueryFilter(ModelBuilder modelBuilder)
        { 
            modelBuilder.Entity<User>().HasQueryFilter(p => !p.IsDeleted);
        }


    }
 
}
