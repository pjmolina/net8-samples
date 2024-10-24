namespace HelloWorld.Collections;

/* index  0 1 2 3 4
 * values 1 2 4 4 4 <-     Stacks LIFO   Queue  FIFO   <- 1 2 3 4 5 6 <-
 * */
public interface IStackOfInt
{
    public void Push(int value);
    public int Peek();
    public int Pop();
    public bool IsEmpty();
}


public class StackOfInt : IStackOfInt
{
    private List<int> list = new();

    public bool IsEmpty() => this.list.Count == 0;
    public int Peek()
    {
        if (IsEmpty())
        {
            throw new Exception("The stack is empty. Invalid operation");
        }
        else
        {
            return list[list.Count - 1];
        }
    }
    public int Pop()
    {
        var v = Peek();
        if (list.Count > 0)
        {
            list.RemoveAt(list.Count - 1);
        }
        return v;
    }
    public void Push(int value)
    {
        list.Add(value);
    }
}
