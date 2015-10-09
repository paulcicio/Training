using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Anagram
{
    [TestClass]
    public class Anagram
    {
        [TestMethod]
        public void AnagramatiseWordWithDuplicateChar()
        {
            Assert.AreEqual(34650, Anagrammatise("mississippi"));
        }

        private int Anagrammatise(string word)
        {
            int numberOfChar = word.Length;

            Dictionary<char, int> countEachLetter = new Dictionary<char, int>();
            foreach (char c in word)
            {
                if (countEachLetter.ContainsKey(c))
                    countEachLetter[c] += 1;
                else
                    countEachLetter[c] = 1;
            }

            int numberOfAnagrams = Factorial(numberOfChar);
            foreach (char a in countEachLetter.Keys)
            {
                numberOfAnagrams = numberOfAnagrams / Factorial(countEachLetter[a]);

            }

            return numberOfAnagrams;

        }

        private int Factorial(int number)
        {
            int result = 1;
            for (int i = 1; i <= number; i++)
            {
                result = result * i;
            }
            return result;
        }
    }
}
