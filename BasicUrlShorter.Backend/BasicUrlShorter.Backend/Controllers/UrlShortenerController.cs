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
    public IActionResult ShortUrl(string fullUrl)
    {
        var shortenedUrl = _urlShortenerService.GenerateShortenedUrl(fullUrl);
        return Ok(shortenedUrl);
    }
    
    [HttpGet("/{shortCode}")]
    public ShortenUrl RedirectUrl(string shortCode)
    {
        var fullUrl = _urlShortenerService.GetFullUrl(shortCode);
        return fullUrl;
        //return Redirect(fullUrl.FullOriginalUrl);
    }
}