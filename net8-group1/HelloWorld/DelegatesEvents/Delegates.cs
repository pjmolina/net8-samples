namespace HelloWorld.DelegatesEvents;

public class Delegates
{
    public delegate int Callback(string message);

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
        // Instantiate the delegate.
        Callback handler = DelegateMethod;

        // Call the delegate.
        handler("Hello World");

    }
}


public delegate void Notify(); // delegate 

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
        ProcessCompleted?.Invoke();
        
    }
}
class Program2
{
    public static void Main()
    {
        ProcessBusinessLogic bl = new ProcessBusinessLogic();
        bl.ProcessCompleted += bl_ProcessCompleted; // register with an event

        bl.StartProcess();
    }
    // event handler 
    public static void bl_ProcessCompleted()
    {
        Console.WriteLine("Process Completed!");
    }
}

