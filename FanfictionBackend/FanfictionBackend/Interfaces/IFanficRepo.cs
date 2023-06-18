using FanfictionBackend.Models;
using FanfictionBackend.Pagination;

namespace FanfictionBackend.Interfaces;

public interface IFanficRepo
{
    public Task AddFanfic(Fanfic fanfic);
    public Task<Fanfic?> GetById(int id);
    public Task<Fanfic?> GetByTitle(string title);

    public Task<PagedList<Fanfic>> GetRecentlyUpdated(PagingParameters pagingParameters);
}
