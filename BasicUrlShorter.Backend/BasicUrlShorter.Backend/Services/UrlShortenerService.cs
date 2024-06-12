using BasicUrlShorter.Backend.Models;
using RandomString4Net;

namespace BasicUrlShorter.Backend.Services;

public class UrlShortenerService
{
    private readonly PostgresContext _postgresContext;
    
    public UrlShortenerService(PostgresContext postgresContext)
    {
        _postgresContext = postgresContext;
    }
    
    public ShortenUrl GenerateShortenedUrl(string fullUrl)
    {
        var shortenUrl = new ShortenUrl
        {
            fullUrl = fullUrl,
            shortenCode = RandomString.GetString(Types.ALPHANUMERIC_MIXEDCASE, 5)
        };
        _postgresContext.ShortenUrls.Add(shortenUrl);
        _postgresContext.SaveChanges();
        return shortenUrl;
    }
}