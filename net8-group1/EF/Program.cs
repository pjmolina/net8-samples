
using EF.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace EF
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            using (var context = new AppDbContext())
            {
                DeleteAll(context);

                CreatePizzas(context);

                QueryPizzas(context);

                IncreasePrice(context, 10);

                QueryPizzas(context);
            }

        }

        private static void IncreasePrice(AppDbContext context, int percent)
        {
            foreach (var pizza in context.Pizzas.AsTracking().ToList())
            {
                pizza.Price = pizza.Price * (1 + (percent / 100.0M));

                // pizza.Price *= 1 + (percent / 100.0M);  // short version
            }

            context.SaveChanges();

        }

        private static void DeleteAll(AppDbContext context)
        {
            

            context.Pizzas.ExecuteDelete(); // delete all
        }

        private static void CreatePizzas(AppDbContext context)
        {
            var pizza1 = new Pizza
            {
                Id = 1,
                Name = "Carbonara",
                Description = "Typical italian pizza",
                Price = 10,
                Ingredients = new List<Ingredient>()
                {
                    new ()
                    {
                        Code = "CHEE",
                        Name = "Cheese",
                        Quantity = 100M
                    }
                }
            };
            var pizza2 = new Pizza
            {
                Id = 2,
                Name = "Margarita",
                Description = "Basic Margarita",
                Price = 8
            };
            var pizza3 = new Pizza
            {
                Id = 3,
                Name = "Tuna",
                Description = "Tuna & Onions",
                Price = 12
            };

            //context.Add(pizza1);
            //context.Add(pizza2);
            //context.Add(pizza3);
            context.AddRange(pizza1, pizza2, pizza3);
            context.SaveChanges();
        }
        private static void QueryPizzas(AppDbContext context)
        {
            // LINQ
            var l1 = context.Pizzas
                .Where(p => p.Name.StartsWith("Carbo") && p.Price < 30)
                .OrderBy(p=> p.Name)
                .ToList();

            context.Pizzas
                .Where(p => p.Name.StartsWith("Carbo") && p.Price < 30)
                .Count();

            // SELECT * from pizza where name LIKE 'Carbo%'

            foreach (var pizza in context.Pizzas.ToList())
            {
                // Console.WriteLine(pizza.Id + " - " + pizza.Name + " -  " + pizza.Price + " EUR");

                Console.WriteLine($"{pizza.Id} - {pizza.Name} - {pizza.Price} EUR");
            }
        }
    }
}
