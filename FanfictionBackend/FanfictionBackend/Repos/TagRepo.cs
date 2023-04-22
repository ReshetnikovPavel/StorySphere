namespace FanfictionBackend.Repos;

public class TagRepo
{
    private readonly FanficDb _dataContext;
    public TagRepo(FanficDb dataContext)
    {
        _dataContext = dataContext;
    }
}