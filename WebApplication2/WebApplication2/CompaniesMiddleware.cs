using Microsoft.Extensions.Options;
using Microsoft.Extensions.Configuration;

namespace WebApplication2
{
    public class MaxEmployeesMiddleware 
    {
        private readonly RequestDelegate _next;
        public Companies companies { get; }

        public MaxEmployeesMiddleware(RequestDelegate next, IOptions<Companies> options)
        {
            _next = next;
            companies = options.Value;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            if (context.Request.Path == "/Max" || context.Request.Path == "/" || context.Request.Path == "") {
                System.Text.StringBuilder stringBuilder = new();
                Company maxCompany = null;
                foreach (Company company in companies.companies)
                {
                    if (maxCompany != null)
                    {
                        if (company.NumOfEmployees < maxCompany.NumOfEmployees)
                        {
                            continue;
                        }
                    }
                    maxCompany = company;
                }

                stringBuilder.Append($"<p>Title: {maxCompany.Title}</li>");
                stringBuilder.Append($"<p>Country: {maxCompany.Country}</li>");
                stringBuilder.Append($"<p>NumOfEmployees: {maxCompany.NumOfEmployees}</li>");
                stringBuilder.Append("<h3>Products</h3><ul style='list-style-type:none;'>");
                foreach (Product product in maxCompany.Products)
                {
                    stringBuilder.Append(
                        $"<li>" +
                            $"<ul>" +
                                $"<li>Name: {product.Name};" +
                                $"<li>Num of users:{product.NumOfUsers}</li> " +
                            $"</ul>" +
                        $"</li><p></p>");
                }
                stringBuilder.Append("</ul>");
                stringBuilder.Append("<hr>");

                await context.Response.WriteAsync(stringBuilder.ToString());
            }
            await _next.Invoke(context);
        }
    }
    public class CompaniesMiddleware
    {
        private readonly RequestDelegate _next;
        public Companies companies { get; }

        public CompaniesMiddleware(RequestDelegate next, IOptions<Companies> options)
        {
            _next = next;
            companies = options.Value;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            if (context.Request.Path == "/Companies")
            {
                System.Text.StringBuilder stringBuilder = new();

                foreach (Company company in companies.companies)
                {
                    stringBuilder.Append($"<p>Title: {company.Title}</li>");
                    stringBuilder.Append($"<p>Country: {company.Country}</li>");
                    stringBuilder.Append($"<p>NumOfEmployees: {company.NumOfEmployees}</li>");
                    stringBuilder.Append("<h3>Products</h3><ul style='list-style-type:none;'>");
                    foreach (Product product in company.Products)
                    {
                        stringBuilder.Append(
                            $"<li>" +
                                $"<ul>" +
                                    $"<li>Name: {product.Name};" +
                                    $"<li>Num of users:{product.NumOfUsers}</li> " +
                                $"</ul>" +
                            $"</li><p></p>");
                    }
                    stringBuilder.Append("</ul>");
                    stringBuilder.Append("<hr>");
                }
                await context.Response.WriteAsync(stringBuilder.ToString());
            }
            await _next.Invoke(context); 
        }
    }

    public class MeMiddleware
    {
        private readonly RequestDelegate _next;
        public Person person { get; }

        public MeMiddleware(RequestDelegate next, IOptions<Person> options)
        {
            _next = next;
            person = options.Value;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            if (context.Request.Path == "/Me")
            {
                System.Text.StringBuilder stringBuilder = new();

                stringBuilder.Append($"<p>Name: {person.Name}</p>");
                stringBuilder.Append($"<p>Age: {person.Age}</p>");
                stringBuilder.Append($"<p>Group: {person.Group}</p>");

                await context.Response.WriteAsync(stringBuilder.ToString());
            }
            await _next.Invoke(context);
        }
    }

    public class TimeMiddleware
    {
        private readonly RequestDelegate _next;
        public TimeMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context, ITimeService timeService)
        {
            if (context.Request.Path == "/Time")
            {
                context.Response.ContentType = "text/html;charset=utf-8";
                await context.Response.WriteAsync($"<h>Time: {timeService.GetTime()}</h>");
            }
            await _next.Invoke(context);
        }
    }
}
