using WebApplication1;

var builder = WebApplication.CreateBuilder();

var app = builder.Build();

app.UseMiddleware<RndDigitMiddleware>();
app.UseMiddleware<BadStatusMiddleware>();
app.UseMiddleware<AuthMiddleware>();
app.UseMiddleware<CompanyMiddleware>();

app.Run();