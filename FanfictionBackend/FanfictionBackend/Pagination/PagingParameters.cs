namespace FanfictionBackend.Pagination;

public class PagingParameters
{
    private const int MaxPageSize = 50;

    public int PageNumber { get; }
    public int PageSize { get; }

    public PagingParameters(int? pageSize, int? pageNumber)
    {
        if (pageNumber < 1)
            throw new ArgumentException("The page number can't be less than 1");
        
        PageNumber = pageNumber ?? 1;
        PageSize = pageSize ?? 10;
    }
}