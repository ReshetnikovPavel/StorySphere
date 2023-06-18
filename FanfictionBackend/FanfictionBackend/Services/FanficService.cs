using FanfictionBackend.Dto;
using FanfictionBackend.Interfaces;
using FanfictionBackend.Models;
using FanfictionBackend.Pagination;

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

    public IResult GetRecentlyUpdatedFanfics(PagingParameters pagingParameters)
    {
        throw new NotImplementedException();
    }

    public IResult GetFanficByTitle(string title)
    {
        throw new NotImplementedException();
    }

    public IResult GetFanficsByAuthor(string authorName, PagingParameters pagingParameters)
    {
        throw new NotImplementedException();
    }

    public IResult AddFanfic(FanficDto fanfic)
    {
        throw new NotImplementedException();
    }

    public IResult AddChapter(ChapterDto chapter, FanficDto toFanfic)
    {
        throw new NotImplementedException();
    }
}