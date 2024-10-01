using WebApi.Models;

namespace WebApi.Repositories
{
    public class PizzaRepository
    {
        private List<Pizza> state = new List<Pizza>();
    
        public PizzaRepository() 
        {
            state.Add(new Pizza()
            {
                Id = 1,
                Name = "Margarita",
                Description = "A basic one",
                Price = 12M,
                IsVegan = true
            });
            state.Add(new Pizza()
            {
                Id = 2,
                Name = "Carbonara",
                Description = "Pizza carbonara with eggs & bacon",
                Price = 14M,
                IsVegan = false
            });
        }

        public List<Pizza> Query()
        {
            return state;
        }
        public Pizza? GetById(int id)
        {
            return state.FirstOrDefault(it => it.Id == id);
        }
        public Pizza Create(Pizza pizza)
        {
            state.Add(pizza);
            return pizza;
        }
        public Pizza Update(int id, Pizza pizza)
        {
            var found = state.FirstOrDefault(it => it.Id == id);
            if (found == null)
            {
                throw new KeyNotFoundException($"Id not found: {id}");
            }

            // Update
            found.Name = pizza.Name;
            found.Description = pizza.Description;
            found.Price = pizza.Price;
            found.IsVegan = pizza.IsVegan;
            return found;
        }
        public Pizza Delete(int id)
        {
            var found = state.FirstOrDefault(it => it.Id == id);
            if (found == null)
            {
                throw new KeyNotFoundException($"Id not found: {id}");
            }

            //Delete
            state.Remove(found);
           
            return found;
        }


    }
}
