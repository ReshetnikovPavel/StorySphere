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

    public async void AddFanfic(Fanfic fanfic)
    {
        await _dataContext.Fanfics.AddAsync(fanfic);
        await _dataContext.SaveChangesAsync();
    }

    public IEnumerable<Fanfic> GetByTitle(string title)
    {
        return _dataContext.Fanfics.Where(f => f.Title == title)
            .Include(f => f.Author)
            .Include(f => f.Likes);
    }

    public IEnumerable<Fanfic> GetRecentlyUpdated(PagingParameters pagingParameters)
    {
        return _dataContext.Fanfics.OrderByDescending(f => f.LastUpdated)
            .Include(f => f.Author)
            .Include(f => f.Likes);;
    }

    public Fanfic? GetById(int id)
    {
        return _dataContext.Fanfics
            .Include(f => f.Chapters)
            .Include(f => f.Author)
            .Include(f => f.Likes)
            .FirstOrDefault(f => f.Id == id);
    }
}
