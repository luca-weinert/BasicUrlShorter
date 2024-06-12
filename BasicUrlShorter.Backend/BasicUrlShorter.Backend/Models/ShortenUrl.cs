using MongoDB.Bson;

namespace BasicUrlShorter.Backend.Models;

public class ShortenUrl
{
    public int ShortenUrlID { get; set; }
    public string fullUrl { get; set; }
    public string? shortenCode { get; set; }
}