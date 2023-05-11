using FanfictionBackend.Services;

namespace Tests;

[TestFixture]
public class PasswordHasherShould
{
    private static readonly PasswordHasher _hasher = new();
    
    [Test]
    public void HashPassword_ShouldReturnDifferentHashes_WhenPasswordsAreDifferent()
    {
        // Arrange
        const string password1 = "password1";
        const string password2 = "password2";
        
        // Act
        var h1 = _hasher.HashPassword(password1);
        var h2 = _hasher.HashPassword(password2);
        
        // Assert
        h1.Should().NotBeEquivalentTo(h2);
    }

    [Test]
    public void VerifyPassword_ShouldReturnTrue_WhenPasswordIsCorrect()
    {
        // Arrange
        var password = "password";
        var hashedPassword = _hasher.HashPassword(password);
        
        // Act
        var result = _hasher.VerifyPassword(password, hashedPassword);
        
        // Assert
        result.Should().BeTrue();
    }
    
    [Test]
    public void VerifyPassword_ShouldReturnFalse_WhenPasswordIsIncorrect()
    {
        // Arrange
        var password = "password";
        var hashedPassword = _hasher.HashPassword(password);
        var wrongPassword = "wrongPassword";
        
        // Act
        var result = _hasher.VerifyPassword(wrongPassword, hashedPassword);
        
        // Assert
        result.Should().BeFalse();
    }
}