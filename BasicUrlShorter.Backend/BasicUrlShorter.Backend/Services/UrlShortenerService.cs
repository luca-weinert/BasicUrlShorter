using BasicUrlShorter.Backend.Models;

namespace BasicUrlShorter.Backend.Services;

public class UrlShortenerService
{
    private readonly MongoDbService _mongoDbService;

    public UrlShortenerService(MongoDbService mongoDbService)
    {
        _mongoDbService = mongoDbService;
    }

    public string GetOriginalUrl(string shortCode)
    {
        var shortenUrl = _mongoDbService.GetDocument(shortCode);
        return shortenUrl.fullUrl;
    }

    public string GetShortenUrl(string originalUrl)
    {
        var shorCode = Guid.NewGuid().ToString();
        
        var test = new ShortenUrl
        {
            fullUrl = originalUrl,
            shortenCode = shorCode
        };
        _mongoDbService.SaveDocument(test);
        return shorCode;
    }
}