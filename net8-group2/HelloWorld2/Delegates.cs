namespace HelloWorld2
{
    public class DelegatesSamples
    {
        public delegate int Callback(string message, int a);

        // Create a method for a delegate.
        public static int DelegateMethod(string message, int b)
        {
            Console.WriteLine(message);
            return 1;
        }


        public void M1()
        {
            // labmda expressing
            // events ->

            // Instantiate the delegate.
            int a = 1;
            Callback pointerToAFunction = null;
            pointerToAFunction = DelegateMethod;

            Callback handler = DelegateMethod;

            // Call the delegate.
            var ab = handler("Hello World", 3);
            pointerToAFunction("sss", 2);


        }

    }
}
