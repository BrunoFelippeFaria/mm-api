using System.Linq.Expressions;

namespace MM.Infrastructure.Extensions;

public static class QueryExtensions 
{
    public static IQueryable<T> WhereIf<T>(
        this IQueryable<T> query,
        bool condition,
        Expression<Func<T, bool>> expression
    )
    {
        if (!condition)
            return query;

        return query.Where(expression);
    }
}