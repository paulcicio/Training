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
            //List<Word> expectedValue = new List<Word>();
            //List<Word> actualValue = new List<Word>();
            Assert.AreEqual(1, CalculateNumberOfOccurrences(text));
        }

        public int CalculateNumberOfOccurrences(string text)
        {
            var set = new HashSet<string>(text.ToLower().Split(' '));
            //for (int i = 0; i < splitted.Length; i++)
            //{
            //    int count = 1;
            //    for (int j = i + 1; j < splitted.Length; j++)
            //    {
            //        if (splitted[i] == splitted[j])
            //        {
            //            count++;
            //        }
            //        else break;
            //    }
            //}
            return 1;
        }

        public Word[] InsertionSort(Word[] array)
        {           
            int index, i, j;
            for (i = 1; i < array.Length; i++)
            {
                index = array[i].counter;
                j = i;
                while ((j > 0) && (array[j - 1].counter > index))
                {
                    array[j].counter = array[j - 1].counter;
                    j = j - 1;
                }
                array[j].counter = index;
            }
            return array;
        }

        public void BinarySearch(Word[] inputArray, int key, int min, int max)
        {
            //if (min > max)            
            //    break;
            
            //else
            //{
                int mid = (min + max) / 2;
                if (key == inputArray[mid].counter)
                {
                     ++mid;
                }
                else if (key < inputArray[mid].counter)
                {
                    BinarySearch(inputArray, key, min, mid - 1);
                }
                else
                {
                    BinarySearch(inputArray, key, mid + 1, max);
                }
            }
        }
    }





