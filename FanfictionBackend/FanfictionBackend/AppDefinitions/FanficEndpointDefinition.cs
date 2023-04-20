using FanfictionBackend.Interfaces;
using FanfictionBackend.Models;

namespace FanfictionBackend.EndpointDefinitions;

public class FanficAppDefinition : IAppDefinition
{
    public void DefineEndpoints(WebApplication app)
    {
        app.MapGet("/", () => "Hello World!");
        app.MapGet("/fanfics", async (IFanficRepo db) => await db.GetAll());

        app.MapPost("/fanfics", async (IFanficRepo db, Fanfic fanfic) =>
        {
            await db.AddFanfic(fanfic);
            return Results.Created($"/fanfic/{fanfic.Id}", fanfic);
        });

        app.MapGet("/fanfics/{id:int}", async (IFanficRepo db, int id) => await db.GetById(id));
    }

    public void DefineServices(IServiceCollection services)
    {
    }
}