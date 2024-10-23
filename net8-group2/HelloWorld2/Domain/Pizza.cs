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

    public void SendMessage(string email, string body)
    {
        // serviceSMTP.SendMail()

        var result = SumNumbers("A", false, 1, true, "A", 'C', 2, 3, 4, 5);
    }
    public int SumNumbers(string res, bool status, params object[] objs)
    {
        // serviceSMTP.SendMail()
        return 0; //...
    }
}

//public class Ingredient
//{
//    public string Name { get; private set; }
//    public int WeightGrams { get; set; }

//    public Ingredient(string name, int weightGrams)
//    {
//        this.Name = name;
//        this.WeightGrams = weightGrams;
//    }
//}

public class Ingredient(string name, int weightGrams = 150)
{
    public string Name { get; set; } = name;
    public int WeightGrams { get; set; } = weightGrams;

    public void AnyMethod()
    {
        this.Name = "Abc"; // valid
    }
    public static int Sum(int a, int b)
    {
        return a + b;
    }
}

