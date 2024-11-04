namespace Api1.Services;

using Api1.Dto;
using Api1.Models;

public interface IPizzaService
{
    public List<PizzaDto> GetAll(PizzaSearchCriteria criteria);
    public PizzaDto? GetById(int id);
    public PizzaDto Create(PizzaDto pizza);
    public PizzaDto Update(int id, PizzaDto pizza);
    public PizzaDto? Delete(int id);
}

public class PizzaService : IPizzaService
{
    private int _seq = 4;

    private List<PizzaDto> fakeDatabase = new List<PizzaDto>()
    {
        new()
        {
            Id = 1,
            Name = "Margarita",
            Description = "Desc for margarita",
            Price = 12
        },
        new()
        {
            Id = 2,
            Name = "Carbonara",
            Description = "Desc for Carbonara",
            Price = 10
        },
       new()
        {
            Id = 3,
            Name = "Cheese",
            Description = "Desc for Cheese",
            Price = 14
        }
    };

    public PizzaDto Create(PizzaDto pizza)
    {
        pizza.Id = _seq++;
        fakeDatabase.Add(pizza);
        return pizza;
    }
    public PizzaDto? Delete(int id)
    {
        var pizza = fakeDatabase.FirstOrDefault(x => x.Id == id);
        if (pizza == null)
        {
            return null;
        }
        else
        {
            fakeDatabase.Remove(pizza);
            return pizza;
        }
    }
    public List<PizzaDto> GetAll(PizzaSearchCriteria criteria)
    {
        IEnumerable<PizzaDto> res = fakeDatabase;

        if (criteria.Query != null)
        {
            res = fakeDatabase.Where(p =>
                 p.Name.Contains(criteria.Query, StringComparison.InvariantCultureIgnoreCase) ||
                 ((p.Description == null)
                    ? false
                    : p.Description.Contains(criteria.Query, StringComparison.InvariantCultureIgnoreCase)
                 )
            );
        }
        if (criteria.MinPrice != null)
        {
            res = res.Where(p => p.Price >= criteria.MinPrice);
        }
        if (criteria.MaxPrice != null)
        {
            res = res.Where(p => p.Price <= criteria.MaxPrice);
        }

        return res.ToList();
    }
    public PizzaDto? GetById(int id)
    {
        // LINQ  .Where(p => p.Name == text)  lambda expression = anonymous function
        var pizza = fakeDatabase.FirstOrDefault(p => p.Id == id);
        if (pizza == null)
        {
            return null;  // we didn't found
        }
        else
        {
            return pizza;
        }
    }
    public PizzaDto Update(int id, PizzaDto pizza)
    {
        var found = fakeDatabase.FirstOrDefault(x => x.Id == id);
        if (found == null)
        {
            // we didn't found
            throw new Exception($"Pizza not found with ID: {id}");
        }
        else
        {
            // update
            found.Name = pizza.Name;
            found.Description = pizza.Description;
            found.Price = pizza.Price;

            return found;
        }
    }

    private bool SameId(PizzaDto pizza, int id)
    {
        return pizza.Id == id;

        //return pizza.Id == id ? true : false; 

        //if (pizza.Id == id)
        //{
        //    return true;
        //}
        //else
        //{
        //    return false;
        //}
    }
}
