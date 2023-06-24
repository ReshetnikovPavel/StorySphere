namespace FanfictionBackend.Services;

public interface ILikeService
{
    IResult AddLike(int fanficId, string userName);
    IResult RemoveLike(int fanficId, string authorName);
}