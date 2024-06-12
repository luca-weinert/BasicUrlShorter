using BasicUrlShorter.Backend.Models;
using RandomString4Net;

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

        var randomString = RandomString.GetString(Types.ALPHANUMERIC_MIXEDCASE, 5);
        var test = new ShortenUrl
        {
            fullUrl = originalUrl,
            shortenCode = randomString
        };
        _mongoDbService.SaveDocument(test);
        return randomString;
    }
}