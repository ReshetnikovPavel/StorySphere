using FanfictionBackend.Models;
using FanfictionBackend.Pagination;

namespace FanfictionBackend.Interfaces;

public interface IFanficRepo
{
    public void AddFanfic(Fanfic fanfic);
    public IEnumerable<Fanfic> GetByTitle(string title);

    public IEnumerable<Fanfic> GetRecentlyUpdated(PagingParameters pagingParameters);
}
