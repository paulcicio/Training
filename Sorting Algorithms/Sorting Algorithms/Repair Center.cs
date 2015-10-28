using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Sorting_Algorithms
{
    [TestClass]
    public class RepairCenter
    {
        enum Priority { High=2, Medium=1, Low=0 };
        
        [TestMethod]
        public void TestMethod1()
        {
            Priority[] expectedValue = new Priority[] { Priority.High, Priority.High, Priority.Medium, Priority.Medium, Priority.Low, Priority.Low };
            Priority[] actualValue = new Priority[] { Priority.Low, Priority.Medium, Priority.High, Priority.Medium, Priority.High, Priority.Low };
            Quicksort(actualValue, 0, 5);
            List<Priority> reverted = new List<Priority>(actualValue);
            reverted.Reverse();               
            CollectionAssert.AreEqual(expectedValue, reverted);
        }

        private int Partition(Priority[] priority, int left, int right)
        {           
            int i, j;
            i = left;
            j = right;
            int pivot = (int)priority[(left + right) / 2];
            while (true)
            {
                while ((int) priority[left] < pivot)
                {
                    left++;
                }
                while ((int) priority[right] > pivot)
                {
                    right--;
                }
                if ((int)priority[right] == pivot && (int)priority[left] == pivot)
                    left++;
                if (left < right)
                {
                    Swap(priority, left, right);
                }
                else
                {
                    return right;
                }
            }
        }

        private static void Swap(Priority[] priority, int left, int right)
        {
            Priority temp = priority[right];
            priority[right] = priority[left];
            priority[left] = temp;
        }

        private void Quicksort(Priority[] priority, int left, int right)
        {
            if (left < right)
            {                
                int pivotIndex = Partition(priority, left, right);                
                Quicksort(priority, left, pivotIndex - 1);                
                Quicksort(priority, pivotIndex + 1, right);
            }
        }
    }
}
            
