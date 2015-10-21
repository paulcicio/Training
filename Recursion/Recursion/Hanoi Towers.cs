using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Recursion
{
    [TestClass]
    public class HanoiTowers
    {
        [TestMethod]
        public void TestMethod1()
        {
            int[] startTower = new int[] { 10, 9, 8, 7, 6, 5, 4, 3, 2, 1 };
            int[] intermediateTower = new int[10];
            int[] endTower = new int[10];
            int [] expectedValue = new int[] { 10, 9, 8, 7, 6, 5, 4, 3, 2, 1 };
            MoveHanoiPlates(4, ref startTower, ref intermediateTower, ref endTower);
            CollectionAssert.AreEqual(expectedValue, endTower); 
        }

        private void MoveHanoiPlates(uint numberOfDisks, ref int[] startTower, ref int[] intermediateTower, ref int[] endTower)
        {
            if (numberOfDisks == 1)
            {
                endTower = startTower;
                Array.Resize(ref startTower, 0);
            }

            else
            {
                MoveHanoiPlates(numberOfDisks - 1, ref startTower, ref endTower, ref intermediateTower);
                MoveHanoiPlates(1, ref startTower, ref intermediateTower, ref endTower);
                MoveHanoiPlates(numberOfDisks - 1, ref intermediateTower, ref startTower, ref endTower);
            }
          
        }
    }
}
