using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;

namespace ProjectEuler
{
    //A palindromic number reads the same both ways. The largest palindrome made from the 
    //product of two 2-digit numbers is 9009 = 91 × 99.

    //Find the largest palindrome made from the product of two 3-digit numbers.

    // This solutions works for 2,3,4 and 5, larger numbers are possible the ints just need
    // to be made into larger number types.
    class Problem4
    {
        private int m_numberOfDigits;
        private double m_highestFactor;
        private double m_lowestFactor;

        public Problem4(int numberOfDigits)
        {
            WriteLine("Problem 4 says hello!");
            WriteLine($"Number of digits: {numberOfDigits}");
            if (numberOfDigits <= 1) return;
            m_numberOfDigits = numberOfDigits;
            int highestFactor = (int)Math.Pow(10, numberOfDigits) - 1;
            int highestProduct = (int)Math.Pow(highestFactor, 2);
            m_highestFactor = highestFactor;
            m_lowestFactor = (int)Math.Pow(10, numberOfDigits - 1);
            while (!IsPalindrome(highestProduct))
            {
                highestProduct--;
            }
            while(!PalindromeHasValidFactors(highestProduct))
            {
                highestProduct = PalindromeDecrement(highestProduct);
            }
        }

        private bool PalindromeHasValidFactors(int palindrome)
        {
            var temp = m_lowestFactor;
            while(temp <= m_highestFactor)
            {
                if((palindrome / temp) % 1 == 0 
                    && (palindrome / temp) <= m_highestFactor 
                    && (palindrome / temp) >= m_lowestFactor)
                {
                    WriteLine($"Success! Palindrome: {palindrome}   {palindrome / temp} * {temp}");
                    return true;
                }
                temp++;
            }
            return false;
        }

        private int PalindromeDecrement(int palindrome)
        {
            var palindromeCache = palindrome;
            List<int> palinByLeastSignificance = new List<int>();
            while (palindromeCache != 0)
            {
                palinByLeastSignificance.Add(palindromeCache % 10);
                palindromeCache /= 10;
            }

            var frontHalf = palindrome / (int)Math.Pow(10, palinByLeastSignificance.Count() / 2);
            frontHalf--;
            var frontHalfCache = frontHalf;
            var decrementedPalin = frontHalf;
            for(int i = palinByLeastSignificance.Count / 2; i < palinByLeastSignificance.Count(); i++)
            {
                decrementedPalin *= 10;
                decrementedPalin += frontHalfCache % 10;
                frontHalfCache /= 10;
            }
            return decrementedPalin;
        }

        private bool IsPalindrome(int candidateNum)
        {
            List<int> numByLeastSignificance = new List<int>();
            while(candidateNum != 0)
            {
                numByLeastSignificance.Add(candidateNum % 10);
                candidateNum /= 10;
            }
            var numByMostSignificance = new List<int>(numByLeastSignificance);
            numByMostSignificance.Reverse();
            if(numByMostSignificance.SequenceEqual(numByLeastSignificance))
            {
                //numByLeastSignificance.ForEach((num) => Write(num));
                //WriteLine("");
                //numByMostSignificance.ForEach((num) => Write(num));
                //WriteLine("\nTrue!");
                return true;
            }
            //numByLeastSignificance.ForEach((num) => Write(num));
            //WriteLine("");
            //numByMostSignificance.ForEach((num) => Write(num));
            //WriteLine("\nFalse!");
            return false;
        }
    }

    // Note: Fun unused parallel palindrome generator before realising it only wants the largest
    /*
    int lowestFactor = (int)Math.Pow(10, numberOfDigits);
    int highestFactor = (int)Math.Pow(10, numberOfDigits + 1) - 1;
    var factorCandidatesRange = Enumerable.Range(lowestFactor, highestFactor);
    var parallelQuery = from fac1 in factorCandidatesRange.AsParallel()
                        from fac2 in factorCandidatesRange.AsParallel()
                        select fac1 * fac2;
    parallelQuery.ForAll((e) => IsPalindrome(e));
    */
}
