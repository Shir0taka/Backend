using WebApplication3;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();

builder.Services.AddTransient<ITimeService, ShortTimeService>();
builder.Services.AddTransient<ICalcService, CalcService>();


var app = builder.Build();

app.UseMiddleware<TimeMiddleware>();
app.UseMiddleware<CalcServiceMiddleware>();

app.Run();
