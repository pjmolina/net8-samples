namespace HelloWorld.Domain;

using System.ComponentModel.DataAnnotations.Schema;

public enum EPizzaState
{
    Order = 1,
    Coocking = 2,
    Delivering = 3,
    Delivered = 4,
    Returned = 5
}

[Table("pizzas")]
public class Pizza
{
   
    public EPizzaState State { get; set; } = EPizzaState.Order;
    public string Name { get; private set; } = string.Empty;
    public string? Description { get; set; }
    public decimal Cost { get; set; }
    public decimal Margin { get; set; } = 1.3M;
    public decimal Price => this.Cost * this.Margin;
    public Ingredient[] Ingredients { get; set; } = [];

    
    public Pizza()
    {        
    }
    public Pizza(string name)
    {
        this.Name = name;
    }

    [Audit("main")]
    // [Authentication(["Admin", "Operator"])]
    // pre {  Open }
    // post { Commit / Abort }
    public static string GetCatalog()
    {
        return "Margarita, Carbonara...";
    }

   
    public void SendEmail(string email, string body)
    {

        // STPM server ... send 
        // service.SendMail (....)
    }

    public int GetEstimatedTimeOfArrival()
    {
        // 1. object
        // 2. tuples
        // 3. out

        // compute
        return 20;
    }
    public Address GetAddress()
    {
        return new Address
        {
            City = "Sevilla",
            Country = "Spain"
            //...
        };
    }
    public Address ModifyAddress(Address adr1)
    {
        adr1.City = "Sevilla";  // side effect
        return adr1;
    }
}

public class Address
{
    public string Street { get; set; } = "";
    public int Number { get; set; }
    public string City { get; set; } = "";
    public string Country { get; set; } = "";
}

public struct Address2
{
    private string street;

    public Address2() => this.Street = "-";

    public string Street { get; set; }
    public int Number { get; set; }
    public string City { get; set; } = "";
    public string Country { get; set; } = "";
}



//public class Ingredient
//{
//    public string Name { get; set; } = "";

//    public Ingredient(string name)
//    {
//        this.Name = name;
//    }
//}

public class Ingredient(string name, int weightGrams)
{
    public string Name { get; set; } = name;
    public int WeightGrams { get; set; } = weightGrams;


    public void Method1()
    { }
}

public class Customer
{
    private string firstName = "";

    public int ReadCount { get; private set; }
    public int WriteCount { get; private set; }

    public string FirstName
    {
        get
        {
            this.ReadCount++;
            return this.firstName;
        }
        set
        {
            this.WriteCount++;
            this.firstName = value;
        }
    } 
    public string LastName { get; set; } = "";

    public string FullName => this.FirstName + " " + this.LastName;

    public Customer()
    { }
    public Customer(string name, string lastname)
    {
        this.LastName = lastname;
        this.FirstName = name;
    }
    public Customer(string name)
    {
        this.FirstName = name;
    }
}

