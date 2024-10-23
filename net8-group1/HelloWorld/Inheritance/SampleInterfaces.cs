namespace HelloWorld.Inheritance;

using System.Runtime.Intrinsics.Arm;
using System.Security.Cryptography;

interface IAnimal
{
    public string Specie { get; set; }

    public void Walk();
}
interface IDog : IAnimal
{
    public  string Color { get; set; }
}
class Pet : IDog
{

    public string Color { get; set; }
    public string Name { get; set; }
    public string Specie { get; set; }

    public void Walk()
    {
        // Implement as needed...
    }
}
