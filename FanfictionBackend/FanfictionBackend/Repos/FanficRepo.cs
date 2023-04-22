using FanfictionBackend.Interfaces;
using FanfictionBackend.Models;
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
}