using System;

namespace HelloWorld2
{
    internal class Program
    {
        static int Sum(int a, int b)
        {
            // var o2 = payload.Clone();


            b = 7;
            return a + b;
        }

        static void Main(string[] args)
        {
            char letterA = 'A';  // Case sensitive means A != a
            char lettera = 'a';

            int a1 = 1;
            int a3 = 3;

            var a = Sum(a1, a3);

            

            string text = "whatever ddddd...";

            letterA = 'B';

            DateTime? today = new DateTime(2024, 10, 21);
            var t0 = DateTime.Now;


            var ellapsed = today - t0;
            if (ellapsed.HasValue)
            {
                Console.Write(ellapsed + " ms");
            }
            else
            {
                Console.Write("no value");
            }


            bool status = true;
            int? n1 = 4;
            float volume = 12F; // EEEI binary  0.3   0101010100101 0.299999999 0 0.30000001 
            double speed = 123245.345589389283D;

            decimal budget = 1234567889.34M;  // BDC  Binary Digit Coding 1010 0 000 9 1001


            var text2 = "eee";
            var age = 20;

            n1 = null;
            var n2 = 6;

            int? n3 = n2 + n1;



            if (n1 == null)
            {
            }
            else
            { 
            }


            Console.WriteLine("Hello, World! .net 8" + age);
        }
    }
}

//  HelloWorld2   -   PascalCase     class names
//  helloWorld2   -   camelCase      variables parameters
//  hello_World   -   snake_Case 
//  hello-World   -   kebab-Case

