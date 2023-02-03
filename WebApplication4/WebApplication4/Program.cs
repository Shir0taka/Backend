using WebApplication4;
using Microsoft.Extensions.Options;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddJsonFile("books.json", optional: true, reloadOnChange: true);
builder.Configuration.AddJsonFile("profiles.json", optional: true, reloadOnChange: true);

builder.Services.Configure<Books>(builder.Configuration.GetSection("Books"));
builder.Services.Configure<Profiles>(builder.Configuration.GetSection("Profiles"));

var app = builder.Build();

app.UseMiddleware<BooksMiddleware>();

app.Map("/Library", () => "Welcome to library!");
app.Map("/Library/Profile/{id:int?}", (int? id, IOptions<Profiles> options) =>
{
    var profiles = options.Value;
    StringBuilder result = new StringBuilder();
    foreach (Profile profile in profiles.profiles)
    {
        int Id = profile.Id;
        var Name = profile.Name;
        var City = profile.City;
        var Year = profile.Year;
        if (id == profile.Id || id == null)
        {
            result.Append($"Id: {Id}; Name: {Name}; City: {City}; Year: {Year}\n");
        }
    }
    var resultString = result.ToString();
    if (resultString.Length == 0) {
        return "No records found!";
    }
    return resultString;
});

app.Use(async (context, next) =>
{
    await next.Invoke();
    if (context.Response.StatusCode == 404)
        await context.Response.WriteAsync("Page not found!");
});

app.Run();
