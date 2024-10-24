namespace HelloWorld2;


public class ErrorHandler
{
    public static void M1()
    {

        try
        {
            int[] myNumbers = { 1, 2, 3 };
            Console.WriteLine(myNumbers[1]);
            Console.WriteLine("last statement of the try");
        }
        catch (IndexOutOfRangeException e)
        {
            Console.WriteLine("out of bound!");
        }
        catch (OutOfMemoryException e)
        {
            Console.WriteLine("no memory");
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        finally
        {
            Console.WriteLine("always");
        }


    }
}

