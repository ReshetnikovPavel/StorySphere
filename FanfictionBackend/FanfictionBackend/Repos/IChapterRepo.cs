using FanfictionBackend.Models;

namespace FanfictionBackend.Interfaces;

public interface IChapterRepo
{
    void AddChapter(Chapter chapter);
}