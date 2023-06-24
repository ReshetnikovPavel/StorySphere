using FanfictionBackend.Models;

namespace FanfictionBackend.Services;

public interface IImageService
{
    public Task<IResult> Upload(IFormFileCollection images, Fanfic fanfic);
    public Task<IResult> Get(string imageId);
}