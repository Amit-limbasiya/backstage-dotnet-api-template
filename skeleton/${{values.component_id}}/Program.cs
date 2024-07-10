using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Information()
    .WriteTo.Console()
    .CreateLogger();

app.UseHttpsRedirection();

app.MapGet("/test", () =>
{
    Log.Information("This is a test GET request!");
});
app.MapPost("/test-post", () =>
{
    Log.Information("This is a test POST request!");
});
app.MapPut("/test-put", () =>
{
    Log.Warning("This is a test PUT request!");
});
app.MapDelete("/test-delete", () =>
{
    Log.Error("This is a test DELETE request!");
});

app.Run();

internal record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
