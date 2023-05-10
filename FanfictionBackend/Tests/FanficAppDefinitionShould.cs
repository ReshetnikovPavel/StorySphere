using FanfictionBackend.EndpointDefinitions;
using FanfictionBackend.Interfaces;
using FanfictionBackend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit;

namespace Tests;

[TestFixture]
public class FanficAppDefinitionShould
{
    private static readonly Mock<IFanficRepo> MockRepo = new();
    private static readonly Fanfic TestFanfic = new() { Id = 1, Title = "Test Title"};
    private static readonly Fanfic[] Fanfics = { TestFanfic};
    
    [SetUp]
    public void SetUp()
    {
        MockRepo.Setup(repo => repo.GetById(It.IsAny<int>()))
            .ReturnsAsync((int id) => Fanfics.FirstOrDefault(fanfic => fanfic.Id == id));
        
        MockRepo.Setup(repo => repo.GetByTitle(It.IsAny<string>()))
            .ReturnsAsync((string title) => Fanfics.FirstOrDefault(fanfic => fanfic.Title == title));
    }


    [Test]
    public async Task GetFanficById_ShouldReturnOk_WhenFanficFound()
    {
        // Act
        var result = await FanficAppDefinition.GetFanficById(MockRepo.Object, TestFanfic.Id);

        // Assert
        Assert.That(result, Is.InstanceOf(typeof(Ok<Fanfic>)));
        Assert.That((result as Ok<Fanfic>)!.Value, Is.EqualTo(TestFanfic));
    }

    [Test]
    public async Task GetFanficById_ShouldReturnNotFound_WhenFanficNotFound()
    {
        // Act
        const int wrongId = 2;
        var result = await FanficAppDefinition.GetFanficById(MockRepo.Object, wrongId);

        // Assert
        Assert.That(result, Is.InstanceOf(typeof(NotFound)));
    }

    [Test]
    public async Task GetFanficByTitle_ShouldRedirect_WhenFanficFound()
    {
        // Act
        var result = await FanficAppDefinition.GetFanficByTitle(MockRepo.Object, TestFanfic.Title);

        // Assert
        Assert.That(result, Is.InstanceOf(typeof(RedirectHttpResult)));
        Assert.That((result as RedirectHttpResult)!.Url, Is.EqualTo($"/fanfics/{TestFanfic.Id}"));
    }

}
