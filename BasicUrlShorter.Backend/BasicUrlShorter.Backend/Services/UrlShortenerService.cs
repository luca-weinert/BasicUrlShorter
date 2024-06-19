using BasicUrlShorter.Backend.Models;
using Microsoft.EntityFrameworkCore;
using RandomString4Net;

namespace BasicUrlShorter.Backend.Services;

public class UrlShortenerService
{
    private readonly PostgresContext _postgresContext;
    
    public UrlShortenerService(PostgresContext postgresContext)
    {
        _postgresContext = postgresContext;
    }

    private async Task<Boolean> CheckGivenUrl(string url)
    {
        var client = new HttpClient();
        var response = await client.GetAsync(url);
        return response.IsSuccessStatusCode;
    }
    
    public async Task<ShortenUrl?> GenerateShortenedUrl(string fullUrl)
    {
        // _postgresContext.Database.EnsureDeleted();
        // _postgresContext.Database.EnsureCreated();
        if (!await CheckGivenUrl(fullUrl))
        {
            Console.WriteLine("Site not responding");
            return null;
        }
        var code = RandomString.GetString(Types.ALPHANUMERIC_MIXEDCASE, 5);
        var shortenUrl = new ShortenUrl
        {
            FullOriginalUrl = fullUrl,
            ShortCode = code,
            FullShortenUrl =  $"{fullUrl}/{code}",
            ClickCounter = 1
        };
        // _postgresContext.Database.EnsureDeleted();
        // _postgresContext.Database.EnsureCreated();
        _postgresContext.ShortenUrls.Add(shortenUrl);
        await _postgresContext.SaveChangesAsync();
        return shortenUrl;

    }

    public ShortenUrl? GetFullUrl(string code)
    {
        var shortenUrl = _postgresContext.ShortenUrls.SingleOrDefault(url => url.ShortCode == code);
        if (shortenUrl == null) return null;
        shortenUrl.ClickCounter++;
        _postgresContext.Entry(shortenUrl).State = EntityState.Modified;
        _postgresContext.SaveChanges();
        return shortenUrl;
    }
}