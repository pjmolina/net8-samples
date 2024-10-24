namespace HelloWorld.Collections;

/* Generic 
 * index  0 1 2 3 4
 * values 1 2 4 4 4 <-     Stacks LIFO   Queue  FIFO   <- 1 2 3 4 5 6 <-
 * 
 * */
public interface IStack<T>
{
    public void Push(T value);
    public T Peek();
    public T Pop();
    public bool IsEmpty();
}


public class Stack<T> : IStack<T>
{
    private List<T> list = new();

    public bool IsEmpty() => this.list.Count == 0;


    /// <summary>
    /// We are taking a look to the top element without removing
    /// </summary>
    /// <returns></returns>
    /// <exception cref="EmptyStackException"></exception>
    public T Peek()
    {
        if (IsEmpty())
        {
            throw new EmptyStackException("custimized message");
        }
        else
        {
            return list[list.Count - 1];
        }
    }
    public T Pop()
    {
        var v = Peek();
        if (list.Count > 0)
        {
            list.RemoveAt(list.Count - 1);
        }
        return v;
    }
    public void Push(T value)
    {
        list.Add(value);
    }
}

public class EmptyStackException : Exception
{

    public EmptyStackException(): base("The stack is empty")
    {
    }
    public EmptyStackException(string message) : base(message)
    {
    }
}


class Example
{
    void Method1()
    {
        var stack = new Stack<string>();
        stack.Push("hola");
        stack.Push("1ww");
        stack.Push("2www");

        try
        {
            stack.Peek();
        }
        catch (EmptyStackException e)
        {
        }


    }
}
