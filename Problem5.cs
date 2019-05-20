using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;

namespace ProjectEuler
{
    //2520 is the smallest number that can be divided by each of the numbers from 1 to 10 
    //without any remainder.

    //What is the smallest positive number that is evenly divisible by all of the numbers from 1 to 20?

    // My solutions is based on my observation 1-10 all fit into 11-20 when doubled enough times.
    class Problem5
    {
        public Problem5()
        {
            WriteLine("Problem5 says Hello!");
            int num = 22;
            while(!IsDivisible(num, 12)
               || !IsDivisible(num, 13)
               || !IsDivisible(num, 14)
               || !IsDivisible(num, 15)
               || !IsDivisible(num, 16)
               || !IsDivisible(num, 17)
               || !IsDivisible(num, 18)
               || !IsDivisible(num, 19)
               || !IsDivisible(num, 20))
            {
                num += 11;
            }
            WriteLine($"Solution: {num}");
        }

        private bool IsDivisible(int num, int factor)
        {
            return num % factor == 0;
        }
    }
}
