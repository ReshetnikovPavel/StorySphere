using System.Net;
using FanfictionBackend.Interfaces;
using FanfictionBackend.Models;
using Imgur.API.Authentication;
using Imgur.API.Endpoints;

namespace FanfictionBackend.Services;

public class ImgurImageService : IImageService
{
    private readonly FanficDb _dataContext;
    private readonly ImageEndpoint _endpoint;
    private readonly IFanficRepo _fanficRepo;

    public ImgurImageService(string key, FanficDb dataContext, IFanficRepo fanficRepo)
    {
        _dataContext = dataContext;
        _fanficRepo = fanficRepo;
        _endpoint = new ImageEndpoint(new ApiClient(key), new HttpClient());
    }

    public async Task<IResult> Upload(IFormFileCollection files, Fanfic fanfic)
    {
        var images = new List<Image>();
        foreach (var file in files)
        {
            var imgurImage = await _endpoint.UploadImageAsync(file.OpenReadStream());
            images.Add(new Image
            {
                Id = imgurImage.Id,
                Link = imgurImage.Link
            });
        }

        fanfic.Images.AddRange(images);
        await _dataContext.SaveChangesAsync();

        return TypedResults.Ok(images);
    }

    public async Task<IResult> Get(Image imageModel)
    {
        var image = await _endpoint.GetImageAsync(imageModel.Id);
        return TypedResults.Ok(image);
    }
}