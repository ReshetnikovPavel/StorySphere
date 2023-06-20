using FanfictionBackend.Pagination;

namespace FanfictionBackend.ExtensionClasses;

public static class EnumerableExtensions
{
    public static PagedList<T> ToPagedList<T>(this IEnumerable<T> source, PagingParameters pp)
    {
        var metadata = new PagingMetadata(source.Count(), pp);
        var items = source.Skip((pp.PageNumber - 1) * pp.PageSize).Take(pp.PageSize);
        return new PagedList<T>(items, metadata);
    }
}