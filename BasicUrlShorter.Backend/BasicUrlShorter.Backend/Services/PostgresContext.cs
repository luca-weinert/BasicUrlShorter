using BasicUrlShorter.Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace BasicUrlShorter.Backend.Services;

public class PostgresContext : DbContext
{
    public DbSet<ShortenUrl> ShortenUrls { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(@"Host=luca-weinert.de;Port=5432;Username=luca;Password=test123#;Database=UrlShortner;");
        optionsBuilder.EnableSensitiveDataLogging();
    }
}