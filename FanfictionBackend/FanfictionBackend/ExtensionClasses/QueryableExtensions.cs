using FanfictionBackend.Pagination;

namespace FanfictionBackend.ExtensionClasses;

public static class QueryableExtensions
{
    public static PagedList<T> ToPagedList<T>(this IQueryable<T> source, PagingParameters pagingParameters) =>
        new(source, pagingParameters);
}