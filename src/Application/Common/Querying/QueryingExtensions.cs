using System.Linq.Expressions;

namespace OrderManagementSystem.Application.Common.Querying
{
    public static class QueryingExtensions
    {
        public static IQueryable<T> WhereIf<T>(this IQueryable<T> query, bool ifCondition, Expression<Func<T, bool>> predicate)
        {
            return ifCondition ? query.Where(predicate) : query;
        }
    }
}
