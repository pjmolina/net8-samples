namespace HelloWorld2.Domain;

using System.ComponentModel.DataAnnotations.Schema;

public enum EPizzaStatus
{
    Order = 1,
    Coocking = 2,
    Delivering = 3,
    Delivered = 4,
    Cancelled = 5
}


public class Pizza
{
    private int id = 0;

    private decimal cost = 0;
    private int costChanges = 0;
    private int readTimes = 0;


    public EPizzaStatus Status { get; set; }
    public string Name { get; set; } = "";
    public string? Description { get; set; }
    public decimal Cost
    {
        get
        {
            readTimes++;
            return cost;
        }
        set
        {
            costChanges++;
            cost = value;
        }
    }
    public decimal Margin { get; set; } = 1.3M;
    public decimal Price => this.Cost * this.Margin;
    public Ingredient[] Ingredients { get; set; } = [];

    public Pizza()
    { }
    public Pizza(string name)
    {
        this.Name = name;
    }
    public Pizza(string name, decimal cost)   // signature
    {
        this.Name = name;
        this.Cost = cost;
    }

    //[Transaction]
    // pre -> {  trx = cnx.OpenTransaction }
    // post -> { trx.Commit / trx.Abort}
    public void SendMessage(string email, string body)
    {
        // serviceSMTP.SendMail()

        var result = SumNumbers("A", false, 1, true, "A", 'C', 2, 3, 4, 5);
    }

    [Authorazition(Role = "admin")]
    public int SumNumbers(string res, bool status, params object[] objs)
    {
        // serviceSMTP.SendMail()
        return 0; //...
    }
}

// Decorator / Metadata

[AttributeUsage(AttributeTargets.Method)]
public class AuthorazitionAttribute: Attribute
{
    public string Role { get; set; }


    public void OnEntry()
    {
        Console.WriteLine("OnEntry");
    }

    public void OnExit()
    {
        Console.WriteLine("OnExit");
    }

    public void OnException(Exception exception)
    {
        Console.WriteLine(string.Format("OnException: {0}: {1}", exception.GetType(), exception.Message));
    }
}

