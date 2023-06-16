using AutoMapper;
using FanfictionBackend.Dto;
using FanfictionBackend.Models;

namespace FanfictionBackend.Interfaces;

public interface IFanficService
{
    Task<IResult> GetRecentlyUpdatedFanfics(int pageNumber, int pageSize);
    Task<IResult> GetFanficByTitle(string? title);
    Task<IResult> GetFanficById(int id);
    Task<IResult> AddFanfic(Fanfic fanfic);
    Task<IResult> AddChapter(Chapter chapter, int id);
}