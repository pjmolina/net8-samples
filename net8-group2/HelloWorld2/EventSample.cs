namespace HelloWorld2;

using static HelloWorld2.EventSample;

public class EventSample
{

    public delegate void Notify(string message); // delegate 

    public class ProcessBusinessLogic
    {
        public event Notify ProcessCompleted; // event
        public event Notify ProcessCancel; // event


        public void StartProcess()
        {
            try
            {
                Console.WriteLine("Process Started!"); // 5 min... 
                OnProcessCompleted();
            }
            catch (Exception e)
            {
                ProcessCancel?.Invoke(e.Message);
            }

        }
        protected virtual void OnProcessCompleted() //protected virtual method 
        { //if ProcessCompleted is not null then call delegate
          
            ProcessCompleted?.Invoke("Process finish OK");

            //if (ProcessCompleted != null)
            //{
            //    ProcessCompleted.Invoke();
            //}
        }
    }
}
public class EventClient
{
    public int Id;

    public EventClient(int id)
    {
        Id = id;
    }

    public void Main2()
    {
        //ProcessBusinessLogic bl = new ProcessBusinessLogic();

        //bl.ProcessCompleted += hadleNotification; // register with an event 

        //bl.StartProcess();

        
    }
    // event handler 
    public void OnComplete(string n)
    {
        // consume the evente here
        Console.WriteLine("Process Completed! " + n);
    }
}

