using FanfictionBackend.Pagination;

namespace FanfictionBackend.ExtensionClasses;

public static class QueryableExtensions
{
    public static Pagination<T> ToPaginationList<T>(this IQueryable<T> source, int pageNumber, int pageSize)
    {
        if (pageNumber <= 0 || pageSize <= 0)
            throw new ArgumentException("Arguments cannot be negative");
        var pageCount = (int)Math.Ceiling((double)source.Count() / pageSize);
        if (pageCount < pageNumber)
            throw new ArgumentException("pageNumber is too big");
        
        var entriesBeforePageCount = (pageNumber - 1) * pageSize;
        var list = source.Skip(entriesBeforePageCount)
            .Take(pageSize)
            .ToList();

        return new Pagination<T>(list, pageNumber != 1, pageNumber != pageCount);
    }
}