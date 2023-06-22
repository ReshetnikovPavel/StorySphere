using System.Net;
using FanfictionBackend.Models;
using Imgur.API.Authentication;
using Imgur.API.Endpoints;

namespace FanfictionBackend.Services;

public class ImgurImageService : IImageService
{
    private readonly ImageEndpoint _endpoint;
    
    public ImgurImageService(string key)
    {
        _endpoint = new ImageEndpoint(new ApiClient(key), new HttpClient());
    }

    public async Task<IResult> Upload(IFormFile imageFile)
    {
        var image = await _endpoint.UploadImageAsync(imageFile.OpenReadStream());
        return TypedResults.Ok(image);
    }

    public async Task<IResult> Get(Image imageModel)
    {
        var image = await _endpoint.GetImageAsync(imageModel.Id);
        return TypedResults.Ok(image);
    }
}