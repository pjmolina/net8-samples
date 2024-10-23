namespace HelloWorld.Domain;


public abstract class Animal
{
    public string Specie;
    public abstract void Walk();

    public Animal() { }
    public Animal(string specie)
    {
        this.Specie = specie;
    }

}
public class Dog : Animal
{
    public string Color;

    public override void Walk()
    {
        Console.WriteLine("Dog walking...");
    }

    public Dog(string specie, string color): base(specie)
    {
        this.Color = color;
    }
}
public class Pet : Dog
{
    public string Name;

    public override void Walk()
    {
        base.Walk();

        Console.WriteLine("Dog walking...");
    }

    public Pet(string specie, string color, string name): base(specie, color)
    {
        this.Name = name;
    }
}







public class Pet2
{
    private int age = 0;
    public void AddYear()
    {

        this.age = this.age + 1;
        //or:   this.age += 1; 
        //or:   this.age++;
    }
    public int GetAge()
    {
        return this.age;
    }
}
