using FanfictionBackend.Models;

namespace FanfictionBackend.Interfaces;

public interface IPasswordHasher
{
    public HashedString HashPassword(string password);
    public bool VerifyPassword(string password, HashedString hashedPassword);
}