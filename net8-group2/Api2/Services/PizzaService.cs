namespace Api2.Services;

using Api2.Dto;

public interface IPizzaService
{
    public List<PizzaDto> GetAll();
    public PizzaDto? GetById(int id);
    public PizzaDto Create(PizzaUpdateDto pizza);
    public PizzaDto? Update(int id, PizzaUpdateDto pizza);
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
            Description = "a desc. for margarita",
            Price = 12
        },
        new()
        {
            Id = 2,
            Name = "Carbonara",
            Description = "a desc. for Carbonara",
            Price = 20
        },
        new()
        {
            Id = 3,
            Name = "Cheese",
            Description = "a desc. for Cheese",
            Price = 14
        }
    };

    public List<PizzaDto> GetAll()
    {
        return fakeDatabase;
    }

    public PizzaDto Create(PizzaUpdateDto pizza)
    {
        // _seq++  postincrement -> use 4m then ++ 5
        // ++_seq  preincrement

        var newPizza = new PizzaDto()
        {
            Id = _seq++,
            Name = pizza.Name,
            Description = pizza.Description,
            Price = pizza.Price
        };
        fakeDatabase.Add(newPizza);
        return newPizza;
    }
  
    public PizzaDto? GetById(int id)
    {
        return fakeDatabase.FirstOrDefault(p => p.Id == id);
    }
    public PizzaDto? Update(int id, PizzaUpdateDto pizza)
    {
        var found = fakeDatabase.FirstOrDefault(p => p.Id == id);
        if (found == null)
        {
            //throw new Exception($"Pizza not found {id}");
            return null;
        }
        else
        {
            found.Name = pizza.Name;
            found.Description = pizza.Description;
            found.Price = pizza.Price;
            return found;
        }

    }
    public PizzaDto? Delete(int id)
    {
        var found = fakeDatabase.FirstOrDefault(p => p.Id == id);
        if (found == null)
        {
            //throw new Exception($"Pizza not found {id}");
            return null;
        }
        else
        {
            fakeDatabase.Remove(found);
            return found;
        }
    }
}
