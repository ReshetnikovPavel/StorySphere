using FanfictionBackend.Dto;
using FanfictionBackend.Pagination;

namespace FanfictionBackend.Services;

public interface IFanficService
{
    IResult GetRecentlyUpdatedFanfics(PagingParameters pagingParameters);
    IResult GetFanficsByTitle(string title, PagingParameters pagingParameters);
    IResult GetFanficsByAuthor(string authorName, PagingParameters pagingParameters);
    IResult GetFanficById(int fanficId);
    IResult AddFanfic(AddFanficDto fanfic, string authorName);
    IResult GetChapter(int fanficId, int chapterNo);
    IResult AddChapter(int fanficId, AddChapterDto chapterDto);
}
