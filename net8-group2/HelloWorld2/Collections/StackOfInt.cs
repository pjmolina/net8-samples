namespace HelloWorld2.Collections;


// A B C D E    Stack LIFO     Queue  1 2 3 4 FIFO
public interface IStackOfInt
{
    public bool IsEmpty();
    public void Push(int value);
    public int Pop();
    public int Peek();
}

public class StackOfInt : IStackOfInt
{
    private List<int> list = [];
    public bool IsEmpty()
    {
        return list.Count == 0;
    }
    public int Peek()
    {
        if (IsEmpty())
        {
            throw new Exception("You cannot peek on an empty list");
        }
        return list[list.Count - 1];
    }
    public int Pop()
    {
        if (IsEmpty())
        {
            throw new Exception("You cannot pop on an empty list");
        }
        var value = Peek();
        list.RemoveAt(list.Count - 1);
        return value;
    }
    public void Push(int value)
    {
        list.Add(value);
    }
}


/*
     var a = new Stack()
     try {
        a.Peek()
     }
     catch...
 
 */


