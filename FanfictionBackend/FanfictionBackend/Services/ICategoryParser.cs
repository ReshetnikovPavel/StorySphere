using FanfictionBackend.Models;

namespace FanfictionBackend.Services;

public interface ICategoryParser
{
    Category Parse(string category);
    string Parse(Category category);
}