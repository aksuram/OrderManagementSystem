using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using OrderManagementSystem.Application.Common.Interfaces;
using OrderManagementSystem.Domain.Entities;
using System.Reflection;

namespace OrderManagementSystem.Infrastructure.Persistence
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        //------------------------------------------------------- How to create or update the database -------------------------------------------------------
        //  0) Check if the "dotnet-ef" tool is installed by typing "dotnet ef" in the main project folder. If not - execute the command below to install it
        //      "dotnet tool install --global dotnet-ef"
        //  1) Add migrations from the main project folder using the command below
        //      "dotnet ef migrations add MIGRATION_NAME --project src\Infrastructure --startup-project src\WebApi --output-dir Persistence\Migrations"
        //  2) Create or update the database from the main project folder using the command below
        //      "dotnet ef database update --project src\Infrastructure --startup-project src\WebApi"

        public required DbSet<Product> Products { get; set; }
        public required DbSet<Discount> Discounts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
#if DEBUG
            //Uncomment for a better debugging experience
            optionsBuilder.EnableSensitiveDataLogging();
            optionsBuilder.LogTo(Console.WriteLine);
#endif
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //Disable the default "on delete cascade" behavior
            foreach (var foreignKey in builder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                foreignKey.DeleteBehavior = DeleteBehavior.Restrict;
            }

            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);
        }

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            return await base.SaveChangesAsync(cancellationToken);
        }

        public async Task<int> SaveChangesAsync()
        {
            return await base.SaveChangesAsync(new CancellationToken());
        }
    }
}
