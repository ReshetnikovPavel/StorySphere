using AutoMapper;
using FanfictionBackend.Dto;
using FanfictionBackend.Models;
using FanfictionBackend.Pagination;

namespace FanfictionBackend.Interfaces;

public interface IFanficService
{
    IResult GetRecentlyUpdatedFanfics(PagingParameters pagingParameters);
    IResult GetFanficsByTitle(string title, PagingParameters pagingParameters);
    IResult GetFanficsByAuthor(string authorName, PagingParameters pagingParameters);
    IResult AddFanfic(AddFanficDto fanfic, string authorName);
    IResult GetChapter(int fanficId, int chapter);
    IResult AddChapter(int fanficId);
}