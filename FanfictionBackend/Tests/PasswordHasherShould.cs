using FanfictionBackend.Services;

namespace Tests;

[TestFixture]
public class PasswordHasherShould
{
    [Test]
    public void HashPassword_ShouldReturnDifferentHashes_WhenPasswordsAreDifferent()
    {
        var hasher = new PasswordHasher();
        var h1 = hasher.
    }
}