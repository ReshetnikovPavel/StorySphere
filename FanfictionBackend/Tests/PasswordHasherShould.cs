using FanfictionBackend.Services;

namespace Tests;

[TestFixture]
public class PasswordHasherShould
{
    [Test]
    public void HashPassword_ShouldReturnDifferentHashes_WhenPasswordsAreDifferent()
    {
        // Arrange
        var hasher = new PasswordHasher();
        const string password1 = "password1";
        const string password2 = "password2";
        
        // Act
        var h1 = hasher.HashPassword(password1, out var s1);
        var h2 = hasher.HashPassword(password2, out var s2);
        
        // Assert
        h1.Should().NotBeEquivalentTo(h2);
    }
}