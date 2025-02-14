using OrderManagementSystem.Application.Common.Models;

namespace OrderManagementSystem.Application.Common.Mappings
{
    public static class MappingExtensions
    {
        public static Task<PaginatedList<T>> PaginatedListAsync<T>(this IQueryable<T> queryable, int pageNumber, int pageSize, CancellationToken cancellationToken)
        {
            return PaginatedList<T>.CreateAsync(queryable, pageNumber, pageSize, cancellationToken);
        }
    }
}
