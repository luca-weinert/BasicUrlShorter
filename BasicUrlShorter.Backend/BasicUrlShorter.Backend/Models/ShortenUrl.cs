using MongoDB.Driver;

namespace BasicUrlShorter.Backend.Models;

public class ShortenUrl
{
    public string fullUrl;
    public string? shortenCode;
}