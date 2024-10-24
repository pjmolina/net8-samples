namespace HelloWorld.Collections;

using HelloWorld.Domain;

public class DictionarySample
{
    void M1()
    {
        var dic = new Dictionary<string, Pizza>();

        dic.Add("PI1", new Pizza("Margarita"));
        dic.Add("PI2", new Pizza("Carbonara"));
        dic.Add("PI3", new Pizza("Diablo"));

        dic.Add("PI3", new Pizza("Vegetarian"));

        var p1 = dic["ZAS"];

        if (dic.ContainsKey("PI5"))
        {
        }


        //  list O(n) 1.2.3.4.4.5.  n/2
        //  hash O(log(n))


        var dicOrders = new Dictionary<int, List<Pizza>>();
    }
}
