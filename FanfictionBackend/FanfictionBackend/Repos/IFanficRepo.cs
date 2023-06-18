using FanfictionBackend.Models;
using FanfictionBackend.Pagination;

namespace FanfictionBackend.Interfaces;

public interface IFanficRepo
{
    public void AddFanfic(Fanfic fanfic);
    public Fanfic? GetByTitle(string title);

    public PagedList<Fanfic> GetRecentlyUpdated(PagingParameters pagingParameters);
}
