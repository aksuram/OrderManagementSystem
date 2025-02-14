﻿using Microsoft.EntityFrameworkCore;
using OrderManagementSystem.Application.Common.Interfaces;
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

        //-------------------- How to create or update the database --------------------
        //  1) Add migrations from the main project folder using the command below
        //      "dotnet ef migrations add MIGRATION_NAME --project src\Infrastructure --startup-project src\WebApi --output-dir Persistence\Migrations"
        //  2) Create or update the database from the main project folder using the command below
        //      "dotnet ef database update --project src\Infrastructure --startup-project src\WebApi"

        //public DbSet<Entity> Entities { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //Uncomment for a better debugging experience
            //optionsBuilder.EnableSensitiveDataLogging();
            //optionsBuilder.LogTo(Console.WriteLine);
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
    }
}
