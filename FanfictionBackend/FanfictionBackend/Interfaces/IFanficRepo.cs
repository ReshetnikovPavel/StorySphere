using FanfictionBackend.Models;

namespace FanfictionBackend.Interfaces;

public interface IFanficRepo
{
    public Task<IList<Fanfic>> GetAll();
    public Task AddFanfic(Fanfic fanfic);
    public Task<Fanfic?> GetById(int id);
    public Task<Fanfic?> GetByTitle(string title);
}