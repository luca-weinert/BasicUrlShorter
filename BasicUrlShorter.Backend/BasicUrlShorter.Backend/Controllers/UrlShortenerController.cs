using Amazon.Runtime.Internal.Transform;
using BasicUrlShorter.Backend.Models;
using BasicUrlShorter.Backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace BasicUrlShorter.Backend.Controllers;

[ApiController]
[Route("")]
public class UrlShortenerController : ControllerBase
{
    private readonly UrlShortenerService _urlShortenerService;
    public UrlShortenerController(UrlShortenerService urlShortenerService, PostgresContext postgresContext)
    {
        _urlShortenerService = urlShortenerService;
    }    

    [HttpPost("/short")]
    public async Task<IActionResult?> ShortUrl(string fullUrl)
    {
        var shortenedUrl = await _urlShortenerService.GenerateShortenedUrl(fullUrl);
        return shortenedUrl == null ? null : Ok(shortenedUrl);
    }
    
    [HttpGet("/{shortCode}")]
    public ShortenUrl RedirectUrl(string shortCode)
    {
        var fullUrl = _urlShortenerService.GetFullUrl(shortCode);
        return fullUrl;
    }
}