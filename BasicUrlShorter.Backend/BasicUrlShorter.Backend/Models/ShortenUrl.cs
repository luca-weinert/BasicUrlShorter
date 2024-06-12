namespace BasicUrlShorter.Backend.Models;

public class ShortenUrl
{
    public int Id { get; set; }
    public string FullOriginalUrl { get; set; }
    public string FullShortenUrl { get; set; }
    public string? ShortCode { get; set; }
    public int ClickCounter { get; set; } = 0;
}