using FanfictionBackend.AppDefinitions;
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
    private static readonly Mock<IFanficRepo> MockFanficRepo = new();
    private static readonly Fanfic TestFanfic = new();
    private static readonly List<Fanfic> Fanfics = new() { TestFanfic };

    private static readonly Mock<IUserRepo> MockUserRepo = new();
    private static readonly User TestUser = new();
    private static readonly List<User> Users = new() { TestUser };

    [SetUp]
    public void SetUp()
    {
        MockFanficRepo.Setup(repo => repo.GetById(It.IsAny<int>()))
            .ReturnsAsync((int id) => Fanfics.FirstOrDefault(fanfic => fanfic.Id == id));

        MockFanficRepo.Setup(repo => repo.GetByTitle(It.IsAny<string>()))
            .ReturnsAsync((string title) => Fanfics.FirstOrDefault(fanfic => fanfic.Title == title));

        MockUserRepo.Setup(repo => repo.AddUser(It.IsAny<User>()))
            .Callback((User user) => Users.Add(user));

        MockUserRepo.Setup(repo => repo.GetByUsername(It.IsAny<string>()))
            .ReturnsAsync((string username) => Users.FirstOrDefault(user => user.Username == username));
    }


    [Test]
    public async Task GetFanficById_ShouldReturnNotFound_WhenFanficNotFound()
    {
        // Arrange
        const int wrongId = 2;

        // Act
        var result = await FanficAppDefinition.GetFanficById(MockFanficRepo.Object, wrongId);

        // Assert
        result.Should().BeOfType<NotFound>();
    }

    [Test]
    public async Task GetFanficByTitle_ShouldRedirect_WhenFanficFound()
    {
        // Arrange
        TestFanfic.Title = "Test Title";

        // Act
        var result = await FanficAppDefinition.GetFanficByTitle(MockFanficRepo.Object, TestFanfic.Title);

        // Assert
        result.Should().BeOfType<RedirectHttpResult>();
        (result as RedirectHttpResult)!.Url.Should().Be($"/fanfic/{TestFanfic.Id}");
    }

    [Test]
    public async Task GetFanficByTitle_ShouldReturnNotFound_WhenFanficNotFound()
    {
        // Arrange
        const string wrongTitle = "Wrong Title";

        // Act
        var result = await FanficAppDefinition.GetFanficByTitle(MockFanficRepo.Object, wrongTitle);

        // Assert
        result.Should().BeOfType<NotFound>();
    }

    [Test]
    public async Task GetFanficByTitle_ShouldReturnBadRequestWithMessage_WhenTitleIsNull()
    {
        // Act
        var result = await FanficAppDefinition.GetFanficByTitle(MockFanficRepo.Object, null);

        // Assert
        result.Should().BeOfType<BadRequest<string>>();
    }

    [Test]
    public async Task RegisterUser_ShouldAddUserToRepo_WhenNewUserIsCorrect()
    {
        // Arrange
        var newUser = new User { Username = "NewUsername" };

        // Act
        var result = await FanficAppDefinition.RegisterUser(MockUserRepo.Object, newUser);

        // Assert
        result.Should().BeOfType<Created>();
        (result as Created)!.Location.Should().Be($"/author/{newUser.Id}");
    }

    [Test]
    public async Task RegisterUser_ShouldReturnConflictWithMessage_WhenUserAlreadyExists()
    {
        // Arrange
        const string testUsername = "TestUsername";
        TestUser.Username = testUsername;
        var newUser = new User { Username = testUsername };

        // Act
        var result = await FanficAppDefinition.RegisterUser(MockUserRepo.Object, newUser);

        // Assert
        result.Should().BeOfType<Conflict<string>>();
    }
}
