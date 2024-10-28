
using System.Linq.Expressions;
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
            context.SaveChanges();   // <- execute on DB
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
                Ingredients =
                [
                    new()
                    {
                        Code = "CHEE",
                        Name = "Cheese",
                        Quantity  = 100
                    }
                ]
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

            var pizza4 = new Pizza
            {
                Id = 4,
                Name = "Carbonara sss",
                Description = "Typical italian pizzasss",
                Price = 102
            };

            // context.Add(pizza1);
            // context.Add(pizza2);
            //context.Add(pizza3);

            try
            {
                context.AddRange(pizza1, pizza2, pizza3, pizza4);
                context.SaveChanges();  // <- SQL executed here
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
        private static void QueryPizzas(AppDbContext context)
        {
            var q1 = context.Pizzas.Count();  // select count(*) from pizza
            // LINQ
            var q2 = context.Pizzas
                    .Where(p => p.Name.StartsWith("Carbo") && p.Price > 1)
                    .OrderBy(p => p.Price)
                    .Skip(60)
                    .Take(20)
                    .ToList();

            Console.WriteLine("q2: " + q2.Count);

            // select * from pizza where name like 'Carbo%' AND  price > 10 order by price asc


            foreach (var pizza in context.Pizzas.ToList())   // Select * from pizza
            {
                // Console.WriteLine(pizza.Id + " - " + pizza.Name + " - " + pizza.Price + " EUR");

                Console.WriteLine($"{pizza.Id} - {pizza.Name} - {pizza.Price} EUR");
            }
        }
    }
}
