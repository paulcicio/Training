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
            int[] startTower = new int[] { 3, 2, 1 };
            int[] intermediateTower = new int[3];
            int[] endTower = new int[3];
            MoveHanoiPlates(3, ref startTower, ref intermediateTower, ref endTower);
            Assert.AreEqual(7, MoveHanoiPlates(3, ref startTower, ref intermediateTower, ref endTower));
        }

        private int MoveHanoiPlates(int numberOfPlates, ref int[] startTower, ref int[] intermediateTower, ref int[] endTower)
        {
            if (numberOfPlates == 0) return 0;
            int numberOfMoves = MoveHanoiPlates(numberOfPlates - 1, ref startTower, ref endTower, ref intermediateTower);
            if (numberOfPlates == 1)
            {
                for (int i = 0; i < startTower.Length; i++)
                {
                    endTower[i] = startTower[i];
                    startTower[i] = 0;
                }
            }
            numberOfMoves++;
            numberOfMoves += MoveHanoiPlates(numberOfPlates - 1, ref intermediateTower, ref startTower, ref endTower);
            return numberOfMoves;
        }
    }
}

