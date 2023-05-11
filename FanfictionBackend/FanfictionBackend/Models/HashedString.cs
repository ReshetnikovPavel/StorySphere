using Microsoft.AspNetCore.Http.HttpResults;

namespace FanfictionBackend.Models;

public struct HashedString
{
    public string Hash { get; }
    public byte[] Salt { get; }

    public HashedString(string hash, byte[] salt)
    {
        Hash = hash;
        Salt = salt;
    }
}