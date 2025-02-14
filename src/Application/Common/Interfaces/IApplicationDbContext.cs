namespace OrderManagementSystem.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        //DbSet<Entity> Entities { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
        int SaveChanges();
    }
}
