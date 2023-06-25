using FanfictionBackend.Models;

namespace FanfictionBackend.Services;

public static class AgeLimitParser
{
    public static AgeLimit Parse(string ageLimit)
    {
        return ageLimit switch
        {
            "G" => AgeLimit.G,
            "PG-13" => AgeLimit.PG13,
            "R" => AgeLimit.R,
            "NC-17" => AgeLimit.NC17,
            "NC-21" => AgeLimit.NC21,
            _ => throw new ArgumentException($"{ageLimit} is not a proper age limit")
        };
    }

    public static string Parse(AgeLimit ageLimit)
    {
        return ageLimit switch
        {
            AgeLimit.G => "G",
            AgeLimit.PG13 => "PG-13",
            AgeLimit.R => "R",
            AgeLimit.NC17 => "NC-17",
            AgeLimit.NC21 => "NC-21",
            _ => throw new ArgumentException($"Can't parse {ageLimit} to string")
        };
    }
}