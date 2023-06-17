using Microsoft.AspNetCore.Http.HttpResults;

namespace FanfictionBackend.Models;

public class Password
{
    public int Id { get; set; }
    public string Hash { get; set; }
    public byte[] Salt { get; set; }
    // public int UserId { get; set; }

    public Password(string hash, byte[] salt)
    {
        Hash = hash;
        Salt = salt;
    }
}