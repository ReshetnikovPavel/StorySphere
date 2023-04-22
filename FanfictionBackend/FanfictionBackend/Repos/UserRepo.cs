using FanfictionBackend.Interfaces;

namespace FanfictionBackend.Repos;

public class UserRepo : IUserRepo
{
    private readonly FanficDb _dataContext;
    public UserRepo(FanficDb dataContext)
    {
        _dataContext = dataContext;
    }
}