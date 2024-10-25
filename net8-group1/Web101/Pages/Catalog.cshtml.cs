using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Web101.Pages
{
    public class CatalogModel : PageModel
    {
        public List<Pizza> Pizzas = [];

        public void OnGet()
        {

            // service to get pizzas
            Pizzas = new List<Pizza>
            {
                new() { Name = "Carbonara" },
                new() { Name = "Margarita" },
                new() { Name = "Cheese" },
                new() { Name = "Pineapple" }
            };
        }
    }

    public class Pizza()
    {
        public string Name { get; set; }
    }
}
