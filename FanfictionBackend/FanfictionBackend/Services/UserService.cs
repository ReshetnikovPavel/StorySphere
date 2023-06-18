using AutoMapper;
using FanfictionBackend.Dto;
using FanfictionBackend.Interfaces;
using FanfictionBackend.Models;
using FanfictionBackend.Pagination;
using FanfictionBackend.Repos;

namespace FanfictionBackend.Services;

public class UserService : IUserService
{
    private readonly IUserRepo _userRepo;
    private readonly IPasswordHasher _hasher;
    private readonly IMapper _mapper;

    public UserService(IUserRepo userRepo, IPasswordHasher hasher, IMapper mapper)
    {
        _userRepo = userRepo;
        _hasher = hasher;
        _mapper = mapper;
    }
    
    public IResult GetUsers(PagingParameters pagingParameters)
    {
        var res = _userRepo.GetUsers(pagingParameters);
        var items = _mapper.Map<IEnumerable<User>, IEnumerable<UserDto>>(res.Items);
        return TypedResults.Ok(new PagedList<UserDto>(items, res.Metadata));
    }

    public IResult GetUserByUsername(string name)
    {
        var res = _userRepo.GetByUsername(name);
        if (res == null)
            return TypedResults.NotFound("User not found");

        return TypedResults.Ok(_mapper.Map<User, UserDto>(res));
    }

    public IResult RegisterUser(UserDto userDto, string password)
    {
        userDto.Username = userDto.Username.ToLower();
        userDto.Email = userDto.Email.ToLower();
        
        var existingUser = _userRepo.GetByUsername(userDto.Username);
        if (existingUser != null)
            return TypedResults.Conflict("Username already taken");
        
        existingUser = _userRepo.GetByEmail(userDto.Username);
        if (existingUser != null)
            return TypedResults.Conflict("Email already registered");
        
        var user = _mapper.Map<UserDto, User>(userDto);
        user.Password = _hasher.HashPassword(password);
        _userRepo.AddUser(user);
        return TypedResults.Created($"/author/{user.Id}");
    }

    public IResult LoginUser(string email, string password)
    {
        var user = _userRepo.GetByEmail(email);
        if (user == null || !_hasher.VerifyPassword(password, user.Password))
            return TypedResults.NotFound("Invalid email or password");
        return Results.Ok(user);
    }
}