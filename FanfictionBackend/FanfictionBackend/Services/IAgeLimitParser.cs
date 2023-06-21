using FanfictionBackend.Models;

namespace FanfictionBackend.Services;

public interface IAgeLimitParser
{
    AgeLimit Parse(string category);
    string Parse(AgeLimit category);
}