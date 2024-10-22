namespace HelloWorld
{
    public enum Color
    { 
        Undefined = 0,
        Orange = 1,
        Red = 2,
        Green = 3,
        Blue = 4,
        Yellow = 5,
        Purple = 123
    }

    public enum CivilStatus
    {
        Single = 'S',
        Married = 'M',
    }


    public class Car
    {
        public string Brand;
        public Color CarColor = Color.Yellow;
       
    }


}
