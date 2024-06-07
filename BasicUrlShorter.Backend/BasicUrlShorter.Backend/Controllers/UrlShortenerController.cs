using BasicUrlShorter.Backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace BasicUrlShorter.Backend.Controllers;

[ApiController]
[Route("")]
public class UrlShortenerController : ControllerBase
{
    private readonly UrlShortenerService _urlShortenerService;
    
    public UrlShortenerController(UrlShortenerService urlShortenerService)
    {
        _urlShortenerService = urlShortenerService;
    }
    
    [HttpPost("/short")]
    public IActionResult ShortUrl(string originalUrl)
    {
        var shortenUrl = _urlShortenerService.GetShortenUrl(originalUrl);
        return Ok(shortenUrl);
    }
    
    [HttpGet("/{shortCode}")]
    public IActionResult RedirectUrl(string shortCode)
    {
        var fullUrl = _urlShortenerService.GetOriginalUrl(shortCode);
        return Redirect(fullUrl);
    }
}