using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Anagram
{
    [TestClass]
    public class Anagram
    {
        [TestMethod]
        public void NoDuplicateChars()
        {
            Assert.AreEqual(119, Anagrammatise("carte"));
        }

        private int Anagrammatise(string word)
        {
            int numberOfChar = word.Length;
            int numberOfAnagrams = (Permutation(numberOfChar)) - 1;
            return numberOfAnagrams;
        }

        private int Permutation(int number)
        {
            int factorial = 1;
            for (int i = 1; i<= number; i++)
            {
                 factorial = factorial * i;
            }
            return factorial;
        }
    }
}
