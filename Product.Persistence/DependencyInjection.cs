using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Products.Application.Interfaces;

namespace Products.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddProductsDbContext(this IServiceCollection services, IConfiguration configuration, string connectionStringName)
        {
            var connectionString = configuration.GetConnectionString(connectionStringName);
            services.AddDbContext<ProductsDbContext>(options =>
                options.UseSqlServer(connectionString));
            services.AddScoped<IProductsDbContext>(provider =>
                provider.GetService<ProductsDbContext>());
            return services;
        }
    }
}
