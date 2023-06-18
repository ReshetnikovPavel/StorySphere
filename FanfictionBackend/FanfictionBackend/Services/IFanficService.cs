using AutoMapper;
using FanfictionBackend.Dto;
using FanfictionBackend.Models;
using FanfictionBackend.Pagination;

namespace FanfictionBackend.Interfaces;

public interface IFanficService
{
    Task<IResult> GetRecentlyUpdatedFanfics(PagingParameters pagingParameters);
    Task<IResult> GetFanficByTitle(string? title);
    Task<IResult> GetFanficById(int id);
    Task<IResult> AddFanfic(Fanfic fanfic);
    Task<IResult> AddChapter(Chapter chapter, int id);
}