using FanfictionBackend.Models;

namespace FanfictionBackend.Services;

public interface IImageService
{
    public Task<IResult> Upload(IFormFile imageFile);
    public Task<IResult> Get(Image imageId);
}