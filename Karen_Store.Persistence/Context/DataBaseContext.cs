using Karen_Store.Application.Interfaces.Context;
using Karen_Store.Common.Role;
using Karen_Store.Domain.Entities.Carts;
using Karen_Store.Domain.Entities.Finance;
using Karen_Store.Domain.Entities.HomePage;
using Karen_Store.Domain.Entities.Products;
using Karen_Store.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;
namespace Karen_Store.Persistence.Context
{
    public class DataBaseContext : DbContext, IDataBaseContext
    {
        public DataBaseContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<UserInRole> UserInRole { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductFeatures> ProductFeatures { get; set; }
        public DbSet<ProductImages> ProductImages { get; set; }
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<HomePageImages> HomePageImage { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<RequestPay> RequestPays { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            SeedData(modelBuilder);
            DataQueryFilter(modelBuilder);
            modelBuilder.Entity<User>().HasIndex(u => u.Email).IsUnique();
        }

        private void SeedData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>().HasData(new Role { Id = 1, Name = nameof(UserRoles.Admin), InsertDateTime = DateTime.MinValue });
            modelBuilder.Entity<Role>().HasData(new Role { Id = 2, Name = nameof(UserRoles.Operator), InsertDateTime = DateTime.MinValue });
            modelBuilder.Entity<Role>().HasData(new Role { Id = 3, Name = nameof(UserRoles.Customer), InsertDateTime = DateTime.MinValue });
            modelBuilder.Entity<Role>().HasData(new Role { Id = 4, Name = nameof(UserRoles.Support), InsertDateTime = DateTime.MinValue });
        }

        private void DataQueryFilter(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasQueryFilter(p => !p.IsDeleted);
            modelBuilder.Entity<Role>().HasQueryFilter(p => !p.IsDeleted);
            modelBuilder.Entity<UserInRole>().HasQueryFilter(p => !p.IsDeleted);
            modelBuilder.Entity<Product>().HasQueryFilter(p => !p.IsDeleted);
            modelBuilder.Entity<ProductFeatures>().HasQueryFilter(p => !p.IsDeleted);
            modelBuilder.Entity<ProductImages>().HasQueryFilter(p => !p.IsDeleted);
            modelBuilder.Entity<Slider>().HasQueryFilter(p => !p.IsDeleted);
            modelBuilder.Entity<HomePageImages>().HasQueryFilter(p => !p.IsDeleted);
            modelBuilder.Entity<Cart>().HasQueryFilter(p => !p.IsDeleted);
            modelBuilder.Entity<CartItem>().HasQueryFilter(p => !p.IsDeleted);
            modelBuilder.Entity<RequestPay>().HasQueryFilter(p => !p.IsDeleted);
        }
    }

}
