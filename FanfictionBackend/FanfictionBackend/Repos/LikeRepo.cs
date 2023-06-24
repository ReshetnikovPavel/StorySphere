using FanfictionBackend.Models;

namespace FanfictionBackend.Repos;

public class LikeRepo : ILikeRepo
{
    private readonly FanficDb _dataContext;

    public LikeRepo(FanficDb dataContext)
    {
        _dataContext = dataContext;
    }

    public void AddLike(Like like)
    {
        _dataContext.Likes.Add(like);
        _dataContext.SaveChanges();
    }

    public void RemoveLike(Like like)
    {
        _dataContext.Likes.Remove(like);
        _dataContext.SaveChanges();
    }
}