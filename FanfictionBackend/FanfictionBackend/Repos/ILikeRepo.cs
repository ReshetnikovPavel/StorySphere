using FanfictionBackend.Models;

namespace FanfictionBackend.Repos;

public interface ILikeRepo
{
    public void AddLike(Like like);
    public void RemoveLike(Like like);
    public bool Exists(Like like);
    public Like? GetLike(int fanficId, string username);
}