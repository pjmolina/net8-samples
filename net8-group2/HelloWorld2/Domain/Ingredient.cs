namespace HelloWorld2.Domain;

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

    private void AnyMethod()
    {
        this.Name = "Abc"; // valid
    }
    public static int Sum(int a, int b)
    {
        return a + b;
    }
}

