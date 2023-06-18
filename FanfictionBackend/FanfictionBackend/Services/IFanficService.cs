using AutoMapper;
using FanfictionBackend.Dto;
using FanfictionBackend.Models;
using FanfictionBackend.Pagination;

namespace FanfictionBackend.Interfaces;

public interface IFanficService
{
    IResult GetRecentlyUpdatedFanfics(PagingParameters pagingParameters);
    IResult GetFanficByTitle(string title);
    IResult GetFanficsByAuthor(string authorName, PagingParameters pagingParameters);
    IResult AddFanfic(AddFanficDto fanfic, string authorName);
}