﻿using AutoMapper;
using FanfictionBackend.Dto;
using FanfictionBackend.ExtensionClasses;
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
    private readonly IImageService _imageService;

    public FanficService(IFanficRepo fanficRepo, IChapterRepo chapterRepo, IUserRepo userRepo, IDateTimeProvider dateTimeProvider, IMapper mapper, IImageService imageService)
    {
        _fanficRepo = fanficRepo;
        _chapterRepo = chapterRepo;
        _userRepo = userRepo;
        _dateTimeProvider = dateTimeProvider;
        _mapper = mapper;
        _imageService = imageService;
    }

    public IResult GetRecentlyUpdatedFanfics(PagingParameters pagingParameters)
    {
        var fanfics = _fanficRepo.GetRecentlyUpdated(pagingParameters)
            .Select(f => _mapper.Map<FanficDto>(f));
        try
        {
            return TypedResults.Ok(fanfics.ToPagedList(pagingParameters));
        }
        catch (ArgumentException e)
        {
            return TypedResults.BadRequest(e.Message);
        }
    }

    IResult IFanficService.GetFanficsByTitle(string title, PagingParameters pagingParameters)
    {
        return GetFanficsByTitle(title, pagingParameters);
    }

    IResult IFanficService.GetFanficsByAuthor(string authorName, PagingParameters pagingParameters)
    {
        return GetFanficsByAuthor(authorName, pagingParameters);
    }

    IResult IFanficService.GetFanficById(int fanficId)
    {
        return GetFanficById(fanficId);
    }

    IResult IFanficService.AddFanfic(AddFanficDto fanfic, string authorName)
    {
        return AddFanfic(fanfic, authorName);
    }

    IResult IFanficService.GetChapter(int fanficId, int chapterNo)
    {
        return GetChapter(fanficId, chapterNo);
    }

    IResult IFanficService.GetRecentlyUpdatedFanfics(PagingParameters pagingParameters)
    {
        return GetRecentlyUpdatedFanfics(pagingParameters);
    }

    public IResult GetFanficsByTitle(string title, PagingParameters pagingParameters)
    {
        var fanfics = _fanficRepo.GetByTitle(title)
            .Select(f => _mapper.Map<FanficDto>(f));
        try
        {
            return TypedResults.Ok(fanfics.ToPagedList(pagingParameters));
        }
        catch (ArgumentException e)
        {
            return TypedResults.BadRequest(e.Message);
        }
    }

    public IResult GetFanficsByAuthor(string? authorName, PagingParameters pagingParameters)
    {
        var author = _userRepo.GetByUsername(authorName);
        if (author is null)
            return TypedResults.NotFound($"Author named {authorName} does not exist");

        var fanfics = author.Fanfics.Select(f => _mapper.Map<FanficDto>(f));

        try
        {
            return TypedResults.Ok(fanfics.ToPagedList(pagingParameters));
        }
        catch (ArgumentException e)
        {
            return TypedResults.BadRequest(e.Message);
        }
    }

    public IResult GetFanficById(int fanficId)
    {
        var fanfic = _fanficRepo.GetById(fanficId);
        if (fanfic is null)
            return TypedResults.NotFound($"Fanfic with {fanficId} does not exist");

        return TypedResults.Ok(_mapper.Map<FanficDto>(fanfic));
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

        var fanficDto = _mapper.Map<FanficDto>(fanfic);
        return TypedResults.Ok(fanficDto);
    }

    public IResult GetChapter(int fanficId, int chapterNo)
    {
        var fanfic = _fanficRepo.GetById(fanficId);
        if (fanfic is null)
            return TypedResults.NotFound($"Fanfic with id {fanficId} not found");

        if (chapterNo <= 0 || fanfic.Chapters.Count < chapterNo)
            return TypedResults.NotFound($"Chapter with chapterNo {chapterNo} not found");

        var chapter = fanfic.Chapters[chapterNo - 1];
        return TypedResults.Ok(_mapper.Map<ChapterDto>(chapter));
    }

    public IResult AddChapter(int fanficId, AddChapterDto addDto, string authorName)
    {
        var fanfic = _fanficRepo.GetById(fanficId);
        if (fanfic is null)
            return TypedResults.NotFound($"Fanfic with id {fanficId} not found");

        if (fanfic.Author.Username != authorName)
            return TypedResults.Forbid();

        var chapter = _mapper.Map<Chapter>(addDto);
        fanfic.Chapters.Add(chapter);
        _chapterRepo.Add(chapter);

        var chapterDto = _mapper.Map<ChapterDto>(chapter);
        return TypedResults.Ok(chapterDto);
    }
}
