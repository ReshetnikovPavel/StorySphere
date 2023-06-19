using FanfictionBackend.Interfaces;
using FanfictionBackend.Models;
using FanfictionBackend.Pagination;
using FanfictionBackend.ExtensionClasses;
using Microsoft.EntityFrameworkCore;

namespace FanfictionBackend.Repos;

public class FanficRepo : IFanficRepo
{
    private readonly FanficDb _dataContext;

    public FanficRepo(FanficDb dataContext)
    {
        _dataContext = dataContext;
    }

    public void AddFanfic(Fanfic fanfic)
    {
        throw new NotImplementedException();
    }

    public Fanfic? GetByTitle(string title)
    {
        throw new NotImplementedException();
    }

    public PagedList<Fanfic> GetRecentlyUpdated(PagingParameters pagingParameters)
    {
        throw new NotImplementedException();
    }
}
