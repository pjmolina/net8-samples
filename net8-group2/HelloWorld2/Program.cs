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

#pragma warning disable IDE0210 // Convert to top-level statements
        static void Main(string[] args)
        {
            char[] letters2 = new char[100];
            char[] letters = { 'A', 'B', 'C', 'D', 'E' };

            char[][] tictoe = [['x', 'x', 'x'], ['x', 'o', ' '], ['x', 'x', 'x']]; // 3x3

            int? myNumber = 5;

            bool? status;
            status = null;


            string text1 = "🍌🐒";

            // UNICODE  chinesse 
            // UTF-8     2 bytes
            // ASCII - 1 byte 0 255 - latin alphabet

            myNumber = 7;
            myNumber = null;





            letters2[0] = 'Z';
            letters2[99] = 'X';
            // letters2[100] = '.';


            char letterA = 'A';  // Case sensitive means A != a
            char lettera = 'a';

            int a1 = 1;
            int a3 = 3;

            var a = Sum(a1, a3);

            double a4 = 9.89;
            int myInt = (int)Math.Round(a4);  // 10



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

            /*  Logical function
                        AND &&  short-circuit
                        OR  ||  short-circuit
                        NOT !a

            !true = false


                AND
                1   AND   1   =>  1
                1   AND   0   =>  0
                0   AND   x1   =>  0
                0   AND   x0   =>  0

                OR
                1   OR   x1   =>  1
                1   OR   x0   =>  1
                0   OR   1   =>  1
                0   OR   0   =>  0

             */

            byte b1 = 0x0F ^ 0xFF;
            /* Bit operands
                & AND bit by bit      1010 & 1000 =>  1000
                | OR
                ^ XOR
                ~ NOT               ~1010 = 0101
             */

            //int? tmp1 = x.M();

            //if (n2 == 4 && n1 > 5 && tmp1 == null && x.M2() )
            //{
            //    // Block A
            //}
            //else
            //{
            //    // Block B

            //}



            var currency = "EUR";

            switch (currency.ToLower())
            {
                case "€":
                case "eur":
                    //statements
                    currency = "usd";
                    break;
                case "$":
                case "usd":
                    //statements
                    break;
                default:
                    //statements
                    break;
            }
            // ...


            for (var i=0; i < letters.Length; i++)
            {
                var letter = letters[i]; // 0-index len=5  0..4    i++  i=i+1  i+=1
                if (letter == 'X')
                {
                    break;
                }
                if (letter == '.')
                {
                    continue;
                }
                // computations
            }
            // P1

            int i = 0;
            while (i < letters.Length)
            {
                // computations
                var letter = letters[i];
                // ...
                i++;
            }
            // 0 or more times


            // 1 or more times
            do
            {
                // computations
                var letter = letters[i];
                // ...
                i++;
            }
            while (i < letters.Length);
            // p2


            // char[] letters = { 'A', 'B', 'C', 'D', 'E' };
            // LINQ
            foreach (var letter in letters)
            {
                // process letter
            }

            // For all x in R


        }



#pragma warning restore IDE0210 // Convert to top-level statements
    }
}

//  HelloWorld2   -   PascalCase     class names
//  helloWorld2   -   camelCase      variables parameters
//  hello_World   -   snake_Case 
//  hello-World   -   kebab-Case

