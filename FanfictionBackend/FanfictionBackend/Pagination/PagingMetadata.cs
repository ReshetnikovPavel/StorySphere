namespace FanfictionBackend.Pagination;

public class PagingMetadata
{
    public int CurrentPage { get; }
    public int TotalPages { get; }
    
    public int PageSize { get; }
    
    public int TotalItems { get; }
    
    public bool HasPrevious => CurrentPage > 1;
    
    public bool HasNext => CurrentPage < TotalPages;

    public PagingMetadata(int totalItems, PagingParameters pagingParams)
    {
        TotalItems = totalItems;
        PageSize = pagingParams.PageSize;
        CurrentPage = pagingParams.PageNumber;
        TotalPages = (int)Math.Ceiling(TotalItems / (double)PageSize);

        if (CurrentPage > TotalPages)
            throw new ArgumentException("Page outside of list");
    }
}