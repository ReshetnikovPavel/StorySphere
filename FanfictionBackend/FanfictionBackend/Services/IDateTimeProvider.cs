namespace FanfictionBackend.Interfaces;

public interface IDateTimeProvider
{
    DateTimeOffset Now { get; }
}