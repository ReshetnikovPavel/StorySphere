using System.Collections;

namespace FanfictionBackend.Pagination;

public class PaginationList<T> : IEnumerable<T>
{
    private readonly List<T> _entries;

    public PaginationList(List<T> entries, bool hasPreviousPage, bool hasNextPage)
    {
        _entries = entries;
        HasPreviousPage = hasPreviousPage;
        HasNextPage = hasNextPage;
    }

    public bool HasPreviousPage { get; }

    public bool HasNextPage { get; }

    public int Count => _entries.Count;

    public IEnumerator<T> GetEnumerator()
    {
        return _entries.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
