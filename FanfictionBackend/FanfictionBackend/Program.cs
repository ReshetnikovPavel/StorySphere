using FanfictionBackend;
using FanfictionBackend.Models;
using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo {
        Title = "Fanfiction API",
        Version = "v1" });
});
builder.Services.AddDbContext<FanficDb>(options => options.UseInMemoryDatabase("items"));

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "PizzaStore API V1");
});

app.MapGet("/", () => "Hello World!");
app.MapGet("/fanfics", async (FanficDb db) => await db.Fanfics.ToListAsync());

app.MapPost("/fanfic", async (FanficDb db, Fanfic fanfic) =>
{
    await db.Fanfics.AddAsync(fanfic);
    await db.SaveChangesAsync();
    return Results.Created($"/fanfic/{fanfic.Id}", fanfic);
});

app.MapGet("/fanfic/{id}", async (FanficDb db, int id) => await db.Fanfics.FindAsync(id));


app.Run();