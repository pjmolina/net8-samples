namespace HelloWorld;

public class ErrorHandling
{
    public static void M1()
    {
        try
        {
            int[] myNumbers = { 1, 2, 3 };
            Console.WriteLine(myNumbers[1]);

            Console.WriteLine("this in inside thy block");
        }
        catch (IndexOutOfRangeException e)
        {
            Console.WriteLine("Index out of bounds.");
        }
        catch (OutOfMemoryException e)
        {
            Console.WriteLine("Out of memery");
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        finally
        {
            Console.WriteLine("We always execute this");
        }

    }
}
