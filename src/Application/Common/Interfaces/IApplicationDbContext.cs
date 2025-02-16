using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using OrderManagementSystem.Domain.Entities;

namespace OrderManagementSystem.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Product> Products { get; set; }
        DbSet<Discount> Discounts { get; set; }
        DbSet<Order> Orders { get; set; }
        DbSet<OrderProduct> OrderProducts { get; set; }
        DatabaseFacade Database { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
        Task<int> SaveChangesAsync();
        int SaveChanges();
    }
}
