using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

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
            listPerSection.Add(new Candidate("Iohannis", 6288769));
            listPerSection.Add(new Candidate("Tonta", 3836093));
            listPerSection.Add(new Candidate("Tariceanu", 508572));
            listPerSection.Add(new Candidate("Macovei", 421648));
            List<List<Candidate>> totalList = new List<List<Candidate>>();
            totalList.Add(listPerSection);
            actualValue = CalculateTotalNumberOfVotes(totalList);
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
            List<Candidate> lists = new List<Candidate>();
            foreach (List<Candidate> list in listPerSection)            
            foreach (Candidate candidate in list)
            {
                Candidate newCandidate = new Candidate();
                newCandidate.name = candidate.name;
                newCandidate.numberOfVotes = candidate.numberOfVotes;

                    Candidate oldCandidate = lists.Find(element => element.name == newCandidate.name);
                    if (oldCandidate.name!=null)
                    {

                        newCandidate.numberOfVotes += oldCandidate.numberOfVotes;
                        lists.Remove(oldCandidate);
                    }

                    lists.Add(newCandidate);
                }
            return lists;
        }

        public List<Candidate> InsertionSort(List<Candidate> list)
        {
            int i, j;
            double index;
            for (i = 1; i < list.Count; i++)
            {
                index = list[i].numberOfVotes;
                j = i;
                var x = list[j];
                while ((j > 0) && (list[j - 1].numberOfVotes > index))
                {
                    x.numberOfVotes = list[j - 1].numberOfVotes;
                    j = j - 1;
                }
                x.numberOfVotes = index;
                list[j--] = x;
            }

            return list;
        }

        public void BinarySearch(List<Candidate> list, double key, int min, int max)
        {
            while (min < max)
            {
                int mid = (min + max) / 2;
                if (key == list[mid].numberOfVotes)
                {
                    ++mid;
                }
                else if (key < list[mid].numberOfVotes)
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

