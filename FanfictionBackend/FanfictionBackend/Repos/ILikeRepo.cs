using FanfictionBackend.Models;

namespace FanfictionBackend.Repos;

public interface ILikeRepo
{
    public void AddLike(Like like);
    public void RemoveLike(Like like);
}