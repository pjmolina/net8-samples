namespace HelloWorld2.Inheritance;

public abstract class Animal
{
    public string Specie { get; set; } = "";

    public Animal(string specie)
    {
        this.Specie = specie;
    }

    public abstract void Feed();º

    public virtual int Walk()
    {
        Console.WriteLine("Animal walking...");
        return 1;
    }
}
public class Dog : Animal
{
    public string Color { get; set; } = "";

    public Dog(string specie, string color): base(specie)
    {
        this.Color = color;
    }
    public void Feed()
    {
        // do somethings
    }

    //public override int Walk()
    //{
    //    Console.WriteLine("Dog walking...");
    //}
}
public class Pet : Dog, IHasName, IHasSurname
{
    public string Name { get; set; } = "";
    public string Surname { get; set; }

    public Pet(string specie, string color, string name) : base(specie, color)
    {
        this.Name = name;
    }
    public override int Walk()
    {
        var res = base.Walk();

        Console.WriteLine("Pet walking...");
        return 5 + res;
    }

    public void Run(int km)
    {
        //....
    }
}

public interface IHasName
{
    public string Name { get; set; }
    public void Run(int km);
}
public interface IHasSurname
{
    public string Surname { get; set; }
}
