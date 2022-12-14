using System.Reflection;
using Products.Application;
using Products.Persistence;
using Products.Application.Common.Mappings;
using Products.Application.Interfaces;

namespace Products.WebApi
{
    public class Program
    {
        public IConfiguration Configuration { get; }
        public Program(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddAutoMapper(config =>
            {
                config.AddProfile(new AssemblyMappingProfile(Assembly.GetExecutingAssembly()));
                config.AddProfile(new AssemblyMappingProfile(typeof(IProductsDbContext).Assembly));
            });
            builder.Services.AddApplication();
            builder.Services.AddProductsDbContext(builder.Configuration, "Products");
            builder.Services.AddSwaggerGen();
            var app = builder.Build();
            DbInitializer.Initialize();
            

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}