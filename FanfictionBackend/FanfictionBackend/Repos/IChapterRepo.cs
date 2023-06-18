using FanfictionBackend.Models;

namespace FanfictionBackend.Interfaces;

public interface IChapterRepo
{
    Task AddChapter(Chapter chapter);
}