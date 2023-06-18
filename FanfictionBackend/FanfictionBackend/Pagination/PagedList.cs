using System.Collections;

namespace FanfictionBackend.Pagination;

public class PagedList<T> : List<T>
{
    public int CurrentPage { get; }
    public int TotalPages { get; }
    public int PageSize { get; }
    public int TotalCount { get; }
    public bool HasPrevious => CurrentPage > 1;
    public bool HasNext => CurrentPage < TotalPages;
    
    public PagedList(IQueryable<T> source, PagingParameters pagingParams)
    {
        TotalCount = source.Count();
        PageSize = pagingParams.PageSize;
        CurrentPage = pagingParams.PageNumber;
        TotalPages = (int)Math.Ceiling(TotalCount / (double)PageSize);

        if (CurrentPage > TotalPages)
            throw new ArgumentException("Page outside of list");
        
        var items = source.Skip((CurrentPage - 1) * PageSize).Take(PageSize);
        
        AddRange(items);
    }
}
