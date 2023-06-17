using FanfictionBackend.Interfaces;
using FanfictionBackend.Models;

namespace FanfictionBackend.Services;

public class UserService : IUserService
{
    private readonly IUserRepo _userRepo;
    private readonly IPasswordHasher _hasher;
    
    public UserService(IUserRepo userRepo, IPasswordHasher hasher)
    {
        _userRepo = userRepo;
        _hasher = hasher;
    }
    
    public async Task<IResult> GetAllUsers()
    {
        var res = await _userRepo.GetAllUsers();
        return TypedResults.Ok(res);
    }

    public async Task<IResult> GetUserById(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<IResult> RegisterUser(User user, string password)
    {
        var existingUser = _userRepo.GetByUsername(user.Username);
        if (existingUser.Result != null)
            return TypedResults.Conflict("Username already registered");
        user.Password = _hasher.HashPassword(password);
        await _userRepo.AddUser(user);
        return TypedResults.Created($"/author/{user.Id}");
    }

    public async Task<IResult> LoginUser(string username, string password)
    {
        var user = await _userRepo.GetByUsername(username);
        if (user == null || !_hasher.VerifyPassword(password, user.Password))
            return TypedResults.NotFound("Invalid username or password");
        return Results.Ok(user);
    }
}