using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Sorting_Algorithms
{
    [TestClass]
    public class WordOccurrence
    {
        public struct Word
        {
            public string word;
            public int counter;
            public Word(string word, int counter)
            {
                this.word = word;
                this.counter = counter;
            }
        }

        [TestMethod]
        public void TestMethod1()
        {
            string text = "To be or not to be";
            List<Word> expectedValue = new List<Word>();  
            expectedValue.Add(new Word("to", 2));
            expectedValue.Add(new Word("be", 2));
            expectedValue.Add(new Word("or", 1));
            expectedValue.Add(new Word("not", 1));
            List<Word> actualValue = new List<Word>();
            actualValue = CalculateNumberOfOccurrences(text);
            CollectionAssert.AreEqual(expectedValue, actualValue);
        }

        public List<Word> CalculateNumberOfOccurrences(string text)
        {
            var set = new HashSet<string>(text.ToLower().Split(' '));
            List<Word> list = new List<Word>();
            foreach (string c in set)
            {
                Word newWord = new Word();
                newWord.word = c;
                newWord.counter = CalculateWordOccurrence(text, c);
                list.Add(newWord);
            }
            return list;
        }

        public int CalculateWordOccurrence(string text, string word)
        {
            string inLowerCase = text.ToLower();
            string newString = inLowerCase.Replace(word, "");
            int counter = (inLowerCase.Length - newString.Length) / word.Length;
            return counter;
        }

        public List<Word> InsertionSort(List<Word> list)
        {
            int index, i, j;
            for (i = 1; i < list.Count; i++)
            {
                index = list[i].counter;
                j = i;
                var x = list[j];
                while ((j > 0) && (list[j - 1].counter > index))
                {
                    x.counter = list[j - 1].counter;
                    j = j - 1;
                }
                x.counter = index;
                list[j--] = x;
            }
            
            return list;
        }

        public void BinarySearch(List<Word> list, int key, int min, int max)
        {
            while (min < max)
            {
                int mid = (min + max) / 2;
                if (key == list[mid].counter)
                {
                    ++mid;
                }
                else if (key < list[mid].counter)
                {
                    BinarySearch(list, key, min, mid - 1);
                }
                else
                {
                    BinarySearch(list, key, mid + 1, max);
                }
            }
        }
    }
}




