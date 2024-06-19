using BasicUrlShorter.Backend.Services;

const string myAllowSpecificOrigin = "_myAllowSpecificOrigins";
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSwaggerGen();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: myAllowSpecificOrigin,
        policy =>
        {
            policy.WithOrigins("http://localhost:3000");
        });
});

builder.Services.AddControllers();
builder.Services.AddSingleton<UrlShortenerService>();
builder.Services.AddSingleton<PostgresContext>();

var app = builder.Build();
app.UseHttpsRedirection();
app.UseCors(myAllowSpecificOrigin);
app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();

app.Run();