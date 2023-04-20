using FanfictionBackend.Models;

namespace FanfictionBackend.Interfaces;

public interface IFanficRepo
{
    public Task<Fanfic[]> GetAll();
    public Task AddFanfic(Fanfic fanfic);
    public Task<Fanfic?> GetById(int id);
}