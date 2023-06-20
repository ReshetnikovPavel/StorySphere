using AutoMapper;
using FanfictionBackend.Dto;
using FanfictionBackend.Interfaces;
using FanfictionBackend.Models;
using FanfictionBackend.Pagination;
using FanfictionBackend.Repos;

namespace FanfictionBackend.Services;

public class FanficService : IFanficService
{
    private readonly IFanficRepo _fanficRepo;
    private readonly IChapterRepo _chapterRepo;
    private readonly IUserRepo _userRepo;
    private readonly IDateTimeProvider _dateTimeProvider;
    private readonly IMapper _mapper;

    public FanficService(IFanficRepo fanficRepo, IChapterRepo chapterRepo, IUserRepo userRepo, IDateTimeProvider dateTimeProvider, IMapper mapper)
    {
        _fanficRepo = fanficRepo;
        _chapterRepo = chapterRepo;
        _userRepo = userRepo;
        _dateTimeProvider = dateTimeProvider;
        _mapper = mapper;
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

    public IResult AddFanfic(AddFanficDto addDto, string authorName)
    {
        var fanfic = _mapper.Map<Fanfic>(addDto);

        var author = _userRepo.GetByUsername(authorName);
        if (author is null)
            return TypedResults.NotFound($"Author named {authorName} does not exist");

        fanfic.Author = author;
        fanfic.Created = _dateTimeProvider.Now;
        fanfic.LastUpdated = fanfic.Created;
        _fanficRepo.AddFanfic(fanfic);
        
        return TypedResults.Ok();
    }
}