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
    private static readonly Mock<IFanficRepo> MockRepo = new();
    private static readonly Fanfic TestFanfic = new() { Id = 1 };
    private static readonly Fanfic[] Fanfics = { TestFanfic};
    
    [SetUp]
    public void SetUp()
    {
        MockRepo.Setup(repo => repo.GetById(It.IsAny<int>()))
            .ReturnsAsync((int id) => Fanfics.FirstOrDefault(fanfic => fanfic.Id == id));
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
}
