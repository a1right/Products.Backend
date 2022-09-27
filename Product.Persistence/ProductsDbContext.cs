using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Products.Application.Interfaces;
using Products.Domain;
using Products.Persistence.EntityTypeConfigurations;

namespace Products.Persistence
{
    public class ProductsDbContext : DbContext, IProductsDbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductVersion> ProductVersions { get; set; }
        public DbSet<EventLog> EventLogs { get; set; }

        public ProductsDbContext(DbContextOptions<ProductsDbContext> options)
            : base(options){}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("Cyrillic_General_100_CI_AS_KS_WS_SC");
            modelBuilder.ApplyConfiguration(new ProductConfiguration())
                        .ApplyConfiguration(new ProductVersionConfiguration())
                        .ApplyConfiguration(new EventLogConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}
