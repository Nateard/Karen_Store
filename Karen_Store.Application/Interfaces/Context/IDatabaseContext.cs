using Karen_Store.Domain.Entities.Carts;
using Karen_Store.Domain.Entities.HomePage;
using Karen_Store.Domain.Entities.Products;
using Karen_Store.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;

namespace Karen_Store.Application.Interfaces.Context
{
    public interface IDatabaseContext
    {
        #region Dbsets
        DbSet<User> Users { get; set; }
        DbSet<Role> Role { get; set; }
        DbSet<UserInRole> UserInRole { get; set; }
        DbSet<Category> Categories { get; set; }
        DbSet<Product> Products { get; set; }
        DbSet<ProductFeatures> ProductFeatures { get; set; }
        DbSet<ProductImages> ProductImages { get; set; }
        DbSet<Slider> Sliders { get; set; }
        DbSet<HomePageImages> HomePageImage { get; set; }
        DbSet<Cart> Carts { get; set; }
        DbSet<CartItem> CartItems { get; set; }
        #endregion


        int SaveChanges(bool acceptAllChangesOnSuccess);
        int SaveChanges();
        Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = new CancellationToken());
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken());

    }


}
