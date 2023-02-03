using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication9.Models;

namespace WebApplication9.Pages
{
    [IgnoreAntiforgeryToken]
    public class IndexModel : PageModel
    {
        public string Message { get; private set; } = "";
        public int Count { get; private set; } = 1;
        public List<Component> Components = new List<Component> { };
        public void OnGet()
        {
            int count_parsed;
            if (int.TryParse(Request.Query["count"], out count_parsed))
            {
                Count = count_parsed;
            }
            else {
                Count = 3;
            }
        }
        public void OnPost(List<Component> components)
        {
            Count = 1;
            Components = components;
            Message = "Added components";
        }

    }
}
