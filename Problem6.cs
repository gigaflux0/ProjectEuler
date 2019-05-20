using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;

namespace ProjectEuler
{
    /*
     * The sum of the squares of the first ten natural numbers is,
     *
     * 12 + 22 + ... + 102 = 385
     * The square of the sum of the first ten natural numbers is,
     *
     * (1 + 2 + ... + 10)2 = 552 = 3025
     * Hence the difference between the sum of the squares of the first ten natural 
     * numbers and the square of the sum is 3025 − 385 = 2640.
     *
     * Find the difference between the sum of the squares of the first one hundred 
     * natural numbers and the square of the sum.
     */

    // My solution is based on the common knowledge that the series of odd numbers are powers
    class Problem6
    {
        public Problem6(int num)
        {
            WriteLine("Problem6 says Hello!");
            int sumOfSquares = 0;
            int temp = 0;
            for (int i = 0, j = 1; i < num; i++, j += 2)
            {
                temp += j;
                sumOfSquares += temp;
            }
            int squareOfSums = 0;
            temp = num;
            while(temp > 0)
            {
                squareOfSums += temp--;
            }
            squareOfSums = (int)Math.Pow(squareOfSums, 2);
            WriteLine($"Answer: {squareOfSums - sumOfSquares}");
        }
    }
}
