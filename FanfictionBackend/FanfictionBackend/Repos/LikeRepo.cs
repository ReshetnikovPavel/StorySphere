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

    public bool Exists(Like like)
    {
        return _dataContext.Likes
            .Any(l => l.Fanfic.Id == like.Fanfic.Id && l.User.Id == like.User.Id);
    }

    public Like? GetLike(int fanficId, string username)
    {
        return _dataContext.Likes
            .FirstOrDefault(l => 
                l.Fanfic.Id == fanficId && string.Equals(l.User.Username, username, 
                    StringComparison.CurrentCultureIgnoreCase));
    }
}