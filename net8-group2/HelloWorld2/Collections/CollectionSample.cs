namespace HelloWorld2.Collections;

using System.Collections;
using System.Collections.Generic;
using HelloWorld2.Domain;
using HelloWorld2.Inheritance;

public enum Color  // enum -> Enumeration
{ }

public class CollectionSample
{
    void M1()
    {
        //  index   0 1 2 3 4 ...
        //  values: A B C C ! F G

        // List, Set  Dictionary Hashmap  index
        // Collection ReadOnlyCollecton array
        // C# IEnumerable



        var letters = new List<char>
        {
            'A',
            'B',
            'C',
            'C'
        };
        // letters.Clear();
        // Block: Comment  | Control+(K ç) |
        letters.Insert(0, 'Z');
        letters.Add('W');
        letters.RemoveAt(0);
        letters.Remove('C');
        var count = letters.Count;
        letters.AddRange(['E', 'F', 'G']);

        if (letters.Contains('Z'))
        {
        }

        var indexOfB = letters.IndexOf('B');

        var e = letters[3];
        letters[3] = '!';


        // Dictionary
        var dic = new Dictionary<int, Customer>();
        dic.Add(1, new Customer() { Name = "A" });
        dic.Add(2, new Customer() { Name = "A1" });
        dic.Add(3, new Customer() { Name = "A2" });
        dic.Add(4, new Customer() { Name = "A3" });
        dic.Add(5, new Customer() { Name = "A4" });
        dic.Add(10000, new Customer() { Name = "A5" });

        var c1 = dic[1000]; // faster

        //  list   O(n)   1M   n/2
        //  dic    O(log(n))

        if (dic.ContainsKey(897))
        {

        }

        foreach (var key in dic.Keys)
        {

        }
        foreach (var val in dic.Values)
        {

        }


        var lk = dic.Keys.ToList();
        var lv = dic.Values.ToList();



        var adr1 = new Address
        {
            Country = "ES",
            Street = " aa"
        };

        var orderDic = new Dictionary<int, List<Pizza>>();





        var p1 = new Pizza("Margarita");
        var p2 = new Pizza("Carbonara");

        var set = new HashSet<Pizza>();
        set.Add(p1);
        set.Add(p2);
        set.Add(p1); // throw an exception

        var pizzaList = new List<Pizza>();

        pizzaList.Sort((a, b) => a.Name.CompareTo(b.Name));


        var comparer = new AlphabeticallyOrdered();

        letters.Sort((char a, char b) => a > b ? 1 : (b > a) ? -1 : 0);
    }



    public interface IHasName
    {
        public string Name { get; set; }
    }

    public class NameComparer : IComparer<IHasName>
    {
        public int Compare(IHasName x, IHasName y)
        {
            return (x.Name.CompareTo(y.Name));
        }
    }

    public class AlphabeticallyOrdered : IComparer<char>
    {
        public int Compare(char x, char y)
        {
            if (x > y)
            {
                return 1;
            }
            if (x < y)
            {
                return -1;
            }
            return 0;
        }
    }

    /*  What means a == b?
     *  
     *  1. a b pointers   a -> 1234 ("hello") <- b
     *  2. a.Equals(b)    a -> 1234 (n"hello" s)  b -> 8000 "hello"
     
     */

    public class Country 
    {
        public string IsoCode { get; set; }
        public string Name { get; set; }

        public override bool Equals(object? obj)
        {
            if (obj == null)
            {
                return false;
            }
            return GetHashCode() == obj.GetHashCode();
        }

        public override int GetHashCode()
        {
            return IsoCode.GetHashCode() ^ Name.GetHashCode();
        }
    }

}
