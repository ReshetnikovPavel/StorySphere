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
        if (title == null)
            return TypedResults.BadRequest("Fanfic title can't be null");
        var fanfic = await _repo.GetByTitle(title);
        return fanfic == null ? TypedResults.NotFound() : TypedResults.Redirect($"/fanfic/{fanfic.Id}");
    }

    public async Task<IResult> GetFanficById(int id)
    {
        var fanfic = await _repo.GetById(id);
        return fanfic == null ? TypedResults.NotFound() : TypedResults.Ok(fanfic);
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