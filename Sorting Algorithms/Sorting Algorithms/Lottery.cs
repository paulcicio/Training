using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Sorting_Algorithms
{
    [TestClass]
    public class Lottery
    {
        [TestMethod]
        public void TestMethod1()
        {
            int[] expectedValue = new int[6] { 7, 9, 10, 17, 31, 47 };
            int[] toSort = new int[6] { 31, 9, 7, 17, 10, 47 };
            int[] actualValue = SortLottoNumbersInOrder(toSort);
            CollectionAssert.AreEqual(expectedValue, actualValue);
        }

        private int[] SortLottoNumbersInOrder(int[] lottoNumbers)
        {
            for (int i = 1; i < 6; i++)
            {
                int j = i;
                while (j > 0)
                {
                    if (lottoNumbers[j - 1] > lottoNumbers[j])
                    {
                        int temp = lottoNumbers[j];
                        lottoNumbers[j] = lottoNumbers[j-1];
                        lottoNumbers[j-1] = temp;                        
                    }
                    j--;
                }
            }
            return lottoNumbers;
        }
    }
}
