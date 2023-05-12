using FanfictionBackend.Models;

namespace FanfictionBackend.Interfaces;

public interface IPasswordHasher
{
    public Password HashPassword(string password);
    public bool VerifyPassword(string password, Password hashedPassword);
}