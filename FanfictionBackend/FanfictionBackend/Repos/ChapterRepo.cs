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
    
    public void AddChapter(Chapter chapter)
    {
        throw new NotImplementedException();
    }
}