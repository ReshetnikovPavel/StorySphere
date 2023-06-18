using System.Collections;

namespace FanfictionBackend.Pagination;

public class PagedList<T>
{
    public PagingMetadata Metadata { get; }
    public IEnumerable<T> Items { get; }
    
    public PagedList(IEnumerable<T> items, PagingMetadata metadata)
    {
        Metadata = metadata;
        Items = items;
    }
}
