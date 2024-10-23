using System;
using System.Security.Cryptography;
using HelloWorld.Domain;

namespace HelloWorld
{
    /// <summary>
    /// Them main entry point
    /// </summary>
    public class Program
    {

        /* multiline comment
         */

        /// <summary>
        /// Add two numbers***
        /// </summary>
        /// <param name="a">the first number</param>
        /// <param name="b">second</param>
        /// <returns>them sum of the numbers</returns>
        static int Add(int a , int b = 0 )
        {
            return a + b;  //single line 
        }

        static void PrintReport(string header = "h1", params object[] numbers )
        {
            //Console.WriteLine(header);
            //foreach (int number in numbers)
            //    Console.WriteLine(number);
        }

        static void Main(string[] args)
        {
            // var a = new Animal();
            var b = new Dog("dog", "white");
            var c = new Pet("dog", "black", "nela");
            // a.Walk();
            b.Walk();
            c.Walk();

            


            var pet1 = new Pet2();
            pet1.AddYear();
            pet1.AddYear();
            pet1.AddYear();
            pet1.GetAge();


            PrintReport("h1", 1, 2, 3, 4, 5, 6, true, "aa");
            PrintReport("h1", 1);
            PrintReport("h1");
            PrintReport();

            var custumer1 = new Customer("Loredana", "Surname");
            var fullname = custumer1.FullName;

            Pizza.GetCatalog();

            // creating an object
            var pizza1 = new Pizza("Margarita");
            //pizza1.Name = "Margarita";
            pizza1.Cost = 10;
            pizza1.Margin = 1.4M;

            // compact way of creating an object
            var pizza2 = new Pizza("Margarita")
            {
                Cost = 10,
                Description = "whatever...",
                Ingredients = [
                    new Ingredient("i1", 100),
                    new Ingredient("i2", 50)
                ]
            };

            pizza2.GetEstimatedTimeOfArrival();

          


            var car1 = new Car();
            car1.Brand = "Honda";
            car1.CarColor = Color.Blue;

            var status = CivilStatus.Married;

            switch (status)
            {
                case CivilStatus.Single:
                    break;
                case CivilStatus.Married:
                    break;
            }


            char[] letters = [ 'A', 'B', 'C'];
            int[] numbers = [ 1, 2, 3, 4];
            int[] nums = { 1, 2, 3, 5, 8 };

            var result2 = nums.Skip(1).Take(3);  //   { 2, 3, 5 }

            double z1 = 9.87;
            int z2 = (int) z1;  // z2 = 9

            int z3 = (int) Math.Round(z1); // z3 = 10

            // int to string
            string s1 = z2.ToString();

            // string to int
            try
            {
                int a24 = int.Parse(s1);
                // statement 2
            }
            catch (FormatException ex)
            {
                 // 1
            }
            catch (ArgumentNullException ex)
            {
                return; // 2
            }
            catch
            {
                return; // 2
            }
            finally
            { 
                // END
            }

            letters.Count(); // 3

            // && AND short-circuit C, C++, Java, C#
            // || OR  short-circuit
            //
            //  AND
            //  1 AND 1 -> 1
            //  1 AND 0 -> 0
            //  0 AND x1 -> 0
            //  0 AND x0 ->
            //  
            //  OR
            //  1 OR x1 -> 1
            //  1 OR x0 -> 1
            //  0 OR 1 -> 1
            //  0 OR 0 -> 0

            byte b0 = 0x00;
            byte mask = 0x0F;

            




            var a1 = letters != null;
            var a2 = letters.Count();

            if (a1 && a2 > 0) 
            {
                // yes
            } 
            else 
            {
                // no
            }

            var currency = "YEN";

            switch (currency.ToLower()) 
            {
                case "yen":
                case "eur":
                    var result1 = "10 EUR";
                    break;
                case "usd":
                    var result4 = "10 USD";
                    break;
                default:
                    var result3 = "10 " + currency;
                    break;
            }
            // continue

            // C
            for (var j=0; j < letters.Length; j++) 
            {
                var letter1 = letters[j];
            }
            
            int k = 0;
            while (k < letters.Length) 
            {
                // statements
                //...
                k++;
            }
            // 0 or more times

            do
            {
                // statements
                //...
                k++;
            }
            while (k < letters.Length);
            // 1 or more times

            // LINQ
            // Lambda
            //foreach (var ch in letters.Where(c => c.Country=="ES") ) 
            //{
                
            //}





            char letter = 'A';
            string someText = "some text";
            int age = 20;
            float n1 = 12.34F;  // binary 0.3 -> binar  0.299999 0.30000001
            double d1 = 12343242.84982394829849D;
            decimal d2 = 1232344235.234M;  // Binary Decimal Coding
            bool result = false;

            age = Add(age, 5);

            Console.WriteLine("Hello, World, NET8!");
            Console.WriteLine("Bye: "  + age);
        }


    }
}


//  HelloWorld          PascalCase
//  helloWorld          camelCase
//  hello_world         snake_Case
//  hello-world         kebabCase
