using FanfictionBackend.Interfaces;
using FanfictionBackend.Models;
using Microsoft.EntityFrameworkCore;

namespace FanfictionBackend;

public class FanficDb : DbContext, IFanficRepo 
{
    public FanficDb(DbContextOptions options) : base(options) { }
    public DbSet<Fanfic> Fanfics { get; set; }
    
    public async Task<IList<Fanfic>> GetAll()
    {
        return await Fanfics.ToArrayAsync();
    }

    public async Task AddFanfic(Fanfic fanfic)
    {
        await Fanfics.AddAsync(fanfic);
        await SaveChangesAsync();
    }

    public async Task<Fanfic?> GetById(int id)
    {
        return await Fanfics.FindAsync(id);
    }
}