using BasicUrlShorter.Backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace BasicUrlShorter.Backend.Controllers;

[ApiController]
[Route("")]
public class UrlShortenerController : ControllerBase
{
    private readonly UrlShortenerService _urlShortenerService;
    private PostgresContext _postgresContext;
    
    public UrlShortenerController(UrlShortenerService urlShortenerService, PostgresContext postgresContext)
    {
        _urlShortenerService = urlShortenerService;
        _postgresContext = postgresContext;
    }    

    [HttpPost("/short")]
    public IActionResult ShortUrl(string fullUrl)
    {
        var ShortenedUrl = _urlShortenerService.GenerateShortenedUrl(fullUrl);
        return Ok(ShortenedUrl);
    }
    
    [HttpGet("/{shortCode}")]
    public IActionResult RedirectUrl(string shortCode)
    {
        // var fullUrl = _urlShortenerService.GetOriginalUrl(shortCode);
        // return Redirect(fullUrl);
        return Ok("test");
    }
}