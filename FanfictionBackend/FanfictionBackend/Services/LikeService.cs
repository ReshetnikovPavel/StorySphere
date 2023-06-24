using System.Globalization;
using FanfictionBackend.Interfaces;
using FanfictionBackend.Models;
using FanfictionBackend.Repos;
using Microsoft.AspNetCore.Http.HttpResults;

namespace FanfictionBackend.Services;

public class LikeService : ILikeService
{
    private readonly IFanficRepo _fanficRepo;
    private readonly IUserRepo _userRepo;
    private readonly ILikeRepo _likeRepo;

    public LikeService(IFanficRepo fanficRepo, IUserRepo userRepo, ILikeRepo likeRepo)
    {
        _fanficRepo = fanficRepo;
        _userRepo = userRepo;
        _likeRepo = likeRepo;
    }
    public IResult AddLike(int fanficId, string userName)
    {
        var fanfic = _fanficRepo.GetById(fanficId);
        if (fanfic == null)
            return TypedResults.NotFound($"Fanfic with id {fanficId} not found");
        
        var user = _userRepo.GetByUsername(userName);
        if (user == null)
            return TypedResults.NotFound($"User with username {userName} not found");
        
        var like = new Like { FanficId = fanficId, Username = userName };
        
        if (_likeRepo.Exists(like))
            return TypedResults.Conflict($"Like by {userName} on fanfic with id {fanficId} already exists");
        
        fanfic.Likes.Add(like);
        user.Likes.Add(like);
        fanfic.Author.ReceivedLikes++;
        _likeRepo.AddLike(like);

        return TypedResults.Ok(like);
    }

    public IResult RemoveLike(int fanficId, string username)
    {
        var fanfic = _fanficRepo.GetById(fanficId);
        if (fanfic == null)
            return TypedResults.NotFound($"Fanfic with id {fanficId} not found");

        var user = _userRepo.GetByUsername(username);
        if (user == null)
            return TypedResults.NotFound($"User with username {username} not found");
        
        var like = _likeRepo.GetLike(fanficId, username);

        if (like == null)
            return TypedResults.NotFound($"Like for fanfic with {fanficId} by {username} does not exist");

        fanfic.Likes.Remove(like);
        user.Likes.Remove(like);
        fanfic.Author.ReceivedLikes--;
        _likeRepo.RemoveLike(like);
        
        return TypedResults.Ok();
    }
}