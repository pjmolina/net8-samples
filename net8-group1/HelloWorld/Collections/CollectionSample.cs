namespace HelloWorld.Collections;

using System.Collections.Generic;
using HelloWorld.Domain;

public class CollectionSample
{
    void Sample()
    {
        // Basic signature of list

        var listOfNums = new List<int>();
        listOfNums.Add(1);
        listOfNums.Add(2);
        listOfNums.Add(3);
        listOfNums.AddRange([ 4, 5, 6]);
        //listOfNums.Clear();
        var c = listOfNums.Count;
        listOfNums.Insert(5, 7);
        listOfNums.Remove(2);
        listOfNums.RemoveAt(0);

        var n2 = listOfNums[2];


        var listOfBools = new List<bool>();
        listOfBools.Add(true);
        listOfBools.Add(false);

        var listOfCustomers = new List<Customer>();

        var listOfObj = new List<object>();
        listOfObj.Add(1);
        listOfObj.Add(true);

    }
}
