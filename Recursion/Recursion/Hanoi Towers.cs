using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Recursion
{
    [TestClass]
    public class HanoiTowers
    {
        [TestMethod]
        public void Hanoi()
        {
            int[] startTower = new int[] { 10, 9, 8, 7, 6, 5, 4, 3, 2, 1 };
            int[] intermediateTower = new int[10];
            int[] endTower = new int[10];
            Assert.AreEqual(1023, MoveHanoiPlates(10, ref startTower, ref intermediateTower, ref endTower));
        }

        private int MoveHanoiPlates(int numberOfPlates, ref int[] startTower, ref int[] intermediateTower, ref int[] endTower)
        {
            if (numberOfPlates == 1)
            {
                endTower[0] = startTower[0];
                for (int i = 0; i < startTower.Length - 1; i++)
                {                                       
                    startTower[i] = startTower[i + 1];
                    
                }
                startTower[startTower.Length - 1] = 0;
                return 1;
            }

            else
            {
                int numberOfMoves = 0;
                numberOfMoves = MoveHanoiPlates(numberOfPlates - 1, ref startTower, ref endTower, ref intermediateTower);
                MoveHanoiPlates(1, ref startTower, ref intermediateTower, ref endTower);
                numberOfMoves++;
                numberOfMoves += MoveHanoiPlates(numberOfPlates - 1, ref intermediateTower, ref startTower, ref endTower);
                return numberOfMoves;
            }
        }
    }
}
