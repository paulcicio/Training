using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace Sorting_Algorithms
{
    [TestClass]
    public class Elections
    {
        public struct Candidate
        {
            public string name;
            public double numberOfVotes;
            public Candidate(string name, int numberOfVotes)
            {
                this.name = name;
                this.numberOfVotes = numberOfVotes;
            }
        }

        [TestMethod]
        public void Election()
        {
            List<Candidate> expectedValue = new List<Candidate>();
            expectedValue.Add(new Candidate("Iohannis", 6288769));
            expectedValue.Add(new Candidate("Tonta", 3836093));
            expectedValue.Add(new Candidate("Tariceanu", 508572));
            expectedValue.Add(new Candidate("Macovei", 421648));
            List<Candidate> actualValue = new List<Candidate>();
            List<Candidate> listPerSection = new List<Candidate>();            
            listPerSection.Add(new Candidate("Tariceanu", 508572));
            listPerSection.Add(new Candidate("Macovei", 421648));
            listPerSection.Add(new Candidate("Iohannis", 6288769));
            listPerSection.Add(new Candidate("Tonta", 3836093));
            List<List<Candidate>> totalList = new List<List<Candidate>>();
            totalList.Add(listPerSection);
            actualValue = CalculateTotalNumberOfVotes(totalList);
            List<Candidate> actual = new List<Candidate>();
            actual = InsertionSort(actualValue);
            CollectionAssert.AreEqual(expectedValue, actualValue);
        }

        [TestMethod]
        public void TwoElectionSections()
        {
            List<Candidate> expectedValue = new List<Candidate>();
            expectedValue.Add(new Candidate("Iohannis", 6288769));
            expectedValue.Add(new Candidate("Tonta", 3836093));
            expectedValue.Add(new Candidate("Tariceanu", 508572));
            expectedValue.Add(new Candidate("Macovei", 421648));
            List<Candidate> actualValue = new List<Candidate>();
            List<Candidate> listPerSection1 = new List<Candidate>();
            listPerSection1.Add(new Candidate("Iohannis", 3000000));
            listPerSection1.Add(new Candidate("Tonta", 2000000));
            listPerSection1.Add(new Candidate("Tariceanu", 308572));
            listPerSection1.Add(new Candidate("Macovei", 200000));
            List<Candidate> listPerSection2 = new List<Candidate>();
            listPerSection2.Add(new Candidate("Iohannis", 3288769));
            listPerSection2.Add(new Candidate("Tonta", 1836093));
            listPerSection2.Add(new Candidate("Tariceanu", 200000));
            listPerSection2.Add(new Candidate("Macovei", 221648));
            List<List<Candidate>> totalList = new List<List<Candidate>>();
            totalList.Add(listPerSection1);
            totalList.Add(listPerSection2);
            actualValue = CalculateTotalNumberOfVotes(totalList);
            CollectionAssert.AreEqual(expectedValue, actualValue);
        }

        public List<Candidate> CalculateTotalNumberOfVotes(List<List<Candidate>> listPerSection)
        {
            List<Candidate> finalList = new List<Candidate>();
            bool found = false;

            for (int i = 0; i < listPerSection.Count; i++)
            {
                List<Candidate> currentSection = listPerSection[i];
                for (int j = 0; j < currentSection.Count; j++)
                {
                    found = false;
                    Candidate currentCandidate = currentSection[j];
                    for (int k = 0; k < finalList.Count; k++)
                    {
                        if (finalList.ElementAt(k).name == currentCandidate.name)
                        {
                            found = true;
                            currentCandidate.numberOfVotes += finalList.ElementAt(k).numberOfVotes;
                            finalList.Remove(finalList.ElementAt(k));
                            finalList.Add(currentCandidate);
                            break;
                        }
                    }
                    if (found == false)
                    {
                        finalList.Add(currentCandidate);
                    }
                }
            }
                        
            return finalList;
        }

        public List<Candidate> InsertionSort(List<Candidate> list)
        {
            int i, j;
           
            for (i = 1; i < list.Count; i++)
            {
                for (int k = i; k > 0 && list[k].numberOfVotes < list[k - 1].numberOfVotes; k--)
                    Swap(list, k, k - 1);               
            }
            list.Reverse();
            return list;
        }

        private static void Swap(List <Candidate> list, int i, int j)
        {
            Candidate aux = list[i];
            list[i] = list[j];
            list[j] = aux;
        }       
    }
}

