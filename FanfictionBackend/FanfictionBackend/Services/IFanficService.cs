using FanfictionBackend.Dto;
using FanfictionBackend.Pagination;

namespace FanfictionBackend.Services;

public interface IFanficService
{
    IResult GetRecentlyUpdatedFanfics(PagingParameters pagingParameters);
    IResult GetFanficByTitle(string title);
    IResult GetFanficsByAuthor(string authorName, PagingParameters pagingParameters);
    IResult AddFanfic(AddFanficDto fanfic, string authorName);
}