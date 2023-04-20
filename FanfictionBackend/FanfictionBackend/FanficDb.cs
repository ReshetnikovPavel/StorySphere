using FanfictionBackend.Interfaces;
using FanfictionBackend.Models;
using Microsoft.EntityFrameworkCore;

namespace FanfictionBackend;

public class FanficDb : DbContext, IFanficRepo 
{
    public FanficDb(DbContextOptions options) : base(options) { }
    
    public readonly DbSet<Fanfic> fanfics = null!;
    public async Task<Fanfic[]> GetAll()
    {
        return await fanfics.ToArrayAsync();
    }

    public async Task AddFanfic(Fanfic fanfic)
    {
        await fanfics.AddAsync(fanfic);
        await SaveChangesAsync();
    }

    public async Task<Fanfic?> GetById(int id)
    {
        return await fanfics.FindAsync(id);
    }
}