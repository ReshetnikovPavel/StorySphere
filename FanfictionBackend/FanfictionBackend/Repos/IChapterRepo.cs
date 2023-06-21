using FanfictionBackend.Models;

namespace FanfictionBackend.Interfaces;

public interface IChapterRepo
{
    void Add(Chapter chapter);
}