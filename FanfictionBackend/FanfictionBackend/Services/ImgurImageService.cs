using System.Net;
using FanfictionBackend.Interfaces;
using FanfictionBackend.Models;
using Imgur.API.Authentication;
using Imgur.API.Endpoints;
using Microsoft.EntityFrameworkCore;

namespace FanfictionBackend.Services;

public class ImgurImageService : IImageService
{
    private readonly FanficDb _dataContext;
    private readonly ImageEndpoint _endpoint;

    public ImgurImageService(string key, FanficDb dataContext)
    {
        _dataContext = dataContext;
        _endpoint = new ImageEndpoint(new ApiClient(key), new HttpClient());
    }

    public async Task<IResult> Upload(IFormFileCollection files, Fanfic fanfic)
    {
        var images = new List<Image>();
        try
        {
            foreach (var file in files)
            {
                var imgurImage = await _endpoint.UploadImageAsync(file.OpenReadStream());
                images.Add(new Image
                {
                    Id = imgurImage.Id,
                    Link = imgurImage.Link
                });
            }
        }
        catch (Imgur.API.ImgurException)
        {
            return TypedResults.BadRequest("One of files is not an image");
        }

        fanfic.Images.AddRange(images);
        await _dataContext.SaveChangesAsync();

        return TypedResults.Ok(images);
    }


    public async Task<IResult> Get(string imageId)
    {
        var image = await _dataContext.Images.FirstOrDefaultAsync(x => x.Id == imageId);
        if (image is null)
            return TypedResults.NotFound($"Image with id {imageId} does not exist");
        return TypedResults.Ok(image);
    }
}