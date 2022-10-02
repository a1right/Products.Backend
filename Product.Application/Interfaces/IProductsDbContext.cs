using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Products.Domain;

namespace Products.Application.Interfaces
{
    public interface IProductsDbContext
    {
        DbSet<Product> Products { get; set; }
        DbSet<ProductVersion> ProductVersions { get; set; }
        DbSet<EventLog> EventLogs { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
