using FanfictionBackend.Interfaces;
using FanfictionBackend.Models;

namespace FanfictionBackend.Repos;

public class ChapterRepo : IChapterRepo
{
    private readonly IDateTimeProvider _dateTimeProvider;
    private readonly FanficDb _dataContext;
    private readonly IFanficRepo _fanficRepo;

    public ChapterRepo(FanficDb dataContext, IFanficRepo fanficRepo, IDateTimeProvider dateTimeProvider)
    {
        _dateTimeProvider = dateTimeProvider;
        _dataContext = dataContext;
        _fanficRepo = fanficRepo;
    }
    
    public async Task AddChapter(Chapter chapter)
    {
        throw new NotImplementedException();
        // _dataContext.Chapters.Add(chapter);
        //
        // var fanfic = await _fanficRepo.GetById(chapter.Fanfic.Id);
        // if (fanfic != null)
        // {
        //     fanfic.Updated = _dateTimeProvider.Now;
        // }
        //
        // await _dataContext.SaveChangesAsync();
    }
}