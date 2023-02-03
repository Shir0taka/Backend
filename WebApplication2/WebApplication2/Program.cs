using WebApplication2;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration
 .AddJsonFile("config.json", optional: true, reloadOnChange: true)
 .AddJsonFile("json.json", optional: true, reloadOnChange: true)
 ;
builder.Services.Configure<Companies>(builder.Configuration.GetSection("1Task"));
builder.Services.Configure<Person>(builder.Configuration.GetSection("2Task").GetSection("person"));

builder.Services.AddTransient<ITimeService, ShortTimeService>();

var app = builder.Build();

app.UseMiddleware<CompaniesMiddleware>();
app.UseMiddleware<MaxEmployeesMiddleware>();
app.UseMiddleware<MeMiddleware>();

app.Run();
