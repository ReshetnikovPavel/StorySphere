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

    public async Task<IList<Fanfic>> GetAll()
    {
        return await _dataContext.Fanfics.ToArrayAsync();
    }

    public async Task AddFanfic(Fanfic fanfic)
    {
        await _dataContext.Fanfics.AddAsync(fanfic);
        await _dataContext.SaveChangesAsync();
    }

    public async Task<Fanfic?> GetById(int id)
    {
        return await _dataContext.Fanfics.FindAsync(id);
    }

    public async Task<Fanfic?> GetByTitle(string title)
    {
        return await _dataContext.Fanfics.FirstOrDefaultAsync(f => f.Title == title);
    }

    public async Task<Pagination<Fanfic>?> GetRecentlyUpdated(int pageNumber, int pageSize)
    {
        return _dataContext.Fanfics.OrderByDescending(f => f.Updated).ToPaginationList(pageNumber, pageSize);
    }
}
