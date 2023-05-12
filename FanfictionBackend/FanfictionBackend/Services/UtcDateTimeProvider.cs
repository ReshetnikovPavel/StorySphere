using FanfictionBackend.Interfaces;

namespace FanfictionBackend.Services;

public class UtcDateTimeProvider : IDateTimeProvider
{
    public DateTimeOffset Now => DateTimeOffset.Now.ToUniversalTime();
}