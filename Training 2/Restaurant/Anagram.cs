using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Anagram
{
    [TestClass]
    public class Anagram
    {
        [TestMethod]
        public void NoDuplicateChars()
        {
            Assert.AreEqual(4, Anagrammatise("mama"));
        }

        private int Anagrammatise(string word)
        {
            int numberOfChar = word.Length;
            int numberOfAnagrams = 0; //(Permutation(numberOfChar)) - 1;
            Dictionary<char, int> countEachLetter = new Dictionary<char, int>(); 
            foreach (char c in word)
            {
                countEachLetter[c]++;
            }
            foreach (char a in countEachLetter.Keys)
            {
                 numberOfAnagrams = Factorial(numberOfChar) / Factorial(countEachLetter[a]);
            }
            return numberOfAnagrams;
            
        }

        private int Factorial(int number)
        {
            int result = 1;
            for (int i = 1; i<= number; i++)
            {
                 result = result * i;
            }
            return result;
        }
    }
}
