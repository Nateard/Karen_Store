using Karen_Store.Domain.Entities.Product;
using Karen_Store.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

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
        #endregion
        int SaveChanges(bool acceptAllChangesOnSuccess);
        int SaveChanges();
        Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = new CancellationToken());
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken());

    }


}
