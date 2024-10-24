namespace HelloWorld2.Collections;


// A B C D E    Stack LIFO     Queue  1 2 3 4 FIFO
public interface IStack<T>
{
    public bool IsEmpty();
    public void Push(T value);
    public T Pop();
    public T Peek();
}

public class Stack<T> : IStack<T>
{
    private List<T> list = [];
    public bool IsEmpty()
    {
        return list.Count == 0;
    }
    public T Peek()
    {
        if (IsEmpty())
        {
            throw new EmptyStackException();
        }
        return list[list.Count - 1];
    }
    public T Pop()
    {
        if (IsEmpty())
        {
            throw new EmptyStackException();
        }
        var value = Peek();
        list.RemoveAt(list.Count - 1);
        return value;
    }
    public void Push(T value)
    {
        list.Add(value);
    }
}

public class EmptyStackException : Exception
{
    public EmptyStackException() : base("The stack is empty")
    { }
}


/*
     var a = new Stack()
     try {
        a.Peek()
     }
     catch...
 
 */


