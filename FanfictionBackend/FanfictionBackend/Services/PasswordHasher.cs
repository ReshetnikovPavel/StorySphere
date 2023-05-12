using System.Security.Cryptography;
using System.Text;
using FanfictionBackend.Interfaces;
using FanfictionBackend.Models;

namespace FanfictionBackend.Services;

public class PasswordHasher : IPasswordHasher
{
    private const int KeySize = 64;
    private const int Iterations = 350000;
    private readonly HashAlgorithmName _hashAlgorithm = HashAlgorithmName.SHA512;
    
    public Password HashPassword(string password)
    {
        var salt = RandomNumberGenerator.GetBytes(KeySize);

        var hash = Rfc2898DeriveBytes.Pbkdf2(
            Encoding.UTF8.GetBytes(password), salt, Iterations, _hashAlgorithm, KeySize);

        return new Password(Convert.ToHexString(hash), salt);
    }

    public bool VerifyPassword(string password, Password hashedPassword)
    {
        var hashToCompare = Rfc2898DeriveBytes.Pbkdf2(
            password, hashedPassword.Salt, Iterations, _hashAlgorithm, KeySize);

        return CryptographicOperations.FixedTimeEquals(hashToCompare, Convert.FromHexString(hashedPassword.Hash));
    }

}