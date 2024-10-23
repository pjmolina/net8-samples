namespace HelloWorld2.Domain;

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
}

public class Ingredient
{
    public string Name;
}

