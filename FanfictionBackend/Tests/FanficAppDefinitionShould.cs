using FanfictionBackend.EndpointDefinitions;
using FanfictionBackend.Interfaces;
using FanfictionBackend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Moq;
using NUnit;

namespace Tests;

[TestFixture]
public class FanficAppDefinitionShould
{
    [Test]
    public async Task GetFanficById_ShouldReturnOk_WhenFanficFound()
    {
        // Arrange
        var mockRepo = new Mock<IFanficRepo>();
        const int id = 1;
        var fakeFanfic = new Fanfic { Id = id };
        var fanfics = new[] { fakeFanfic };
        
        mockRepo.Setup(repo => repo.GetById(id)).ReturnsAsync(fanfics.First(x => x.Id == id));

        // Act
        var result = await FanficAppDefinition.GetFanficById(mockRepo.Object, id);

        // Assert
        Assert.That(result, Is.InstanceOf(typeof(Ok<Fanfic>)));
        Assert.That((result as Ok<Fanfic>)!.Value, Is.EqualTo(fakeFanfic));
    }

    [Test]
    public async Task GetFanficById_ShouldReturnNotFound_WhenFanficNotFound()
    {
        // Arrange
        var mockRepo = new Mock<IFanficRepo>();
        const int id = 1;
        var fakeFanfic = new Fanfic { Id = id };
        var fanfics = new[] { fakeFanfic };
        
        mockRepo.Setup(repo => repo.GetById(id)).ReturnsAsync(fanfics.First(x => x.Id == id));
        
        // Act
        const int wrongId = 2;
        var result = await FanficAppDefinition.GetFanficById(mockRepo.Object, wrongId);

        // Assert
        Assert.That(result, Is.InstanceOf(typeof(NotFound)));
    }
}