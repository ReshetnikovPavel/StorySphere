using FanfictionBackend.Models;

namespace FanfictionBackend.Services;

public static class CategoryParser
{
    public static Category Parse(string category)
    {
        return category switch
        {
            "Slash" => Category.MM,
            "Femslash" => Category.FF,
            "Hetero" => Category.FM,
            "General" => Category.None,
            "Mixed" => Category.Multi,
            "Article" => Category.Article,
            "Other" => Category.Other,
            _ => Category.NotStated,
        };
    }

    public static string Parse(Category category)
    {
        return category switch
        {
            Category.FF => "Slash",
            Category.FM => "Femslash",
            Category.MM => "Hetero",
            Category.Multi => "Mixed",
            Category.None => "General",
            Category.Other => "Other",
            Category.Article => "Article",
            _ => "Не указано"
        };
    }
}