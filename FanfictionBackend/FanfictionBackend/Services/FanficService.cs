using FanfictionBackend.Interfaces;
using FanfictionBackend.Models;

namespace FanfictionBackend.Services;

public class FanficService : IFanficService
{
    private readonly IFanficRepo _repo;
    
    public FanficService(IFanficRepo repo)
    {
        _repo = repo;
    }
    
    public async Task<IResult> GetRecentlyUpdatedFanfics(int pageNumber, int pageSize)
    {
        try
        {
            return TypedResults.Ok(await _repo.GetRecentlyUpdated(pageNumber, pageSize));
        }
        catch (ArgumentException e)
        {
            return TypedResults.BadRequest(e);
        }
    }

    public async Task<IResult> GetFanficByTitle(string? title)
    {
        throw new NotImplementedException();
    }

    public async Task<IResult> GetFanficById(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<IResult> AddFanfic(Fanfic fanfic)
    {
        throw new NotImplementedException();
    }

    public async Task<IResult> AddChapter(Chapter chapter, int id)
    {
        throw new NotImplementedException();
    }
}