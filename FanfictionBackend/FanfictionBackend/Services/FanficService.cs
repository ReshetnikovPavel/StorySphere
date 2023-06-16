using FanfictionBackend.Interfaces;
using FanfictionBackend.Models;

namespace FanfictionBackend.Services;

public class FanficService : IFanficService
{
    private readonly IFanficRepo _fanficRepo;
    private readonly IChapterRepo _chapterRepo;
    private readonly IDateTimeProvider _dateTimeProvider;
    
    public FanficService(IFanficRepo fanficRepo, IChapterRepo chapterRepo, IDateTimeProvider dateTimeProvider)
    {
        _fanficRepo = fanficRepo;
        _chapterRepo = chapterRepo;
        _dateTimeProvider = dateTimeProvider;
    }
    
    public async Task<IResult> GetRecentlyUpdatedFanfics(int pageNumber, int pageSize)
    {
        try
        {
            return TypedResults.Ok(await _fanficRepo.GetRecentlyUpdated(pageNumber, pageSize));
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
        var fanfic = await _fanficRepo.GetByTitle(title);
        return fanfic == null ? TypedResults.NotFound() : TypedResults.Redirect($"/fanfic/{fanfic.Id}");
    }

    public async Task<IResult> GetFanficById(int id)
    {
        var fanfic = await _fanficRepo.GetById(id);
        return fanfic == null ? TypedResults.NotFound() : TypedResults.Ok(fanfic);
    }

    public async Task<IResult> AddFanfic(Fanfic fanfic)
    {
        fanfic.Created = _dateTimeProvider.Now;
        fanfic.Updated = fanfic.Created;
        
        await _fanficRepo.AddFanfic(fanfic);
        return TypedResults.Ok();
    }

    public async Task<IResult> AddChapter(Chapter chapter, int id)
    {
        chapter.FanficId = id;
        
        await _chapterRepo.AddChapter(chapter);
        return TypedResults.Ok();
    }
}