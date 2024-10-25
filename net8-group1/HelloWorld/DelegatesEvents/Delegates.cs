namespace HelloWorld.DelegatesEvents;

public class Delegates
{
    public delegate int Callback(string message);

    public delegate int Sum(int a, int b);  //  (int, int) -> int

    public static int Add(int x, int y)
    {
        return x + y;
    }

    // Create a method for a delegate.
    public static int DelegateMethod(string message)
    {
        Console.WriteLine(message);
        return 0;
    }

    public static int DelegateMethod2(string message)
    {
        Console.WriteLine("v2" + message);
        return 1;
    }
    public void M1()
    {
        Sum pointerAFunction = null;

        pointerAFunction = Add;

        var c = pointerAFunction.Invoke(1, 2);


        // Instantiate the delegate.
        Callback handler = DelegateMethod;

        // Call the delegate.
        handler("Hello World");

    }
}


public delegate bool Notify(string message); // delegate 

public class ProcessBusinessLogic
{
    public event Notify ProcessCompleted; // event 
    public event Notify ProcessCancelled; // event 
    public void StartProcess()
    {
        Console.WriteLine("Process Started!");
        // some code here.. 
        OnProcessCompleted();
    }
    protected virtual void OnProcessCompleted() //protected virtual method 
    { //if ProcessCompleted is not null then call delegate      
        var result = ProcessCompleted?.Invoke("something happeng");
        
    }
}
public class Program2
{
    public static void Main2()
    {
        ProcessBusinessLogic bl = new ProcessBusinessLogic();

        bl.ProcessCompleted += ProcessFinish; // register with an event

        bl.StartProcess();
    }
    // event handler 
    public static bool ProcessFinish(string m)
    {
        Console.WriteLine("Process Completed!" + m);
        return true;
    }
}

