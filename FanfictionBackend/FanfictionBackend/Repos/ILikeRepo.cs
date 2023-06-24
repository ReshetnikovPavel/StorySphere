using FanfictionBackend.Models;

namespace FanfictionBackend.Repos;

public interface ILikeRepo
{
    public void AddLike(Like like);
    public void RemoveLike(Like like);
    public bool Exists(int fanficId, string username);
    public Like? GetLike(int fanficId, string username);
}