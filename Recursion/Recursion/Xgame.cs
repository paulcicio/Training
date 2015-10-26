using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Recursion
{
    [TestClass]
    public class Xgame
    {
        [TestMethod]
        public void TestMethod1()
        {
            Assert.AreEqual(11, CalculateNumberOfWinningMoves(matrix[2][1], 4));
        }

        private int CalculateNumberOfWinningMoves(int[][] matrix, int n)
        {
            int count = 0;                                  
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (matrix[i - 1, j]==0 && matrix[i + 1, j]==0 &&
                        matrix[i, j - 1]==0 && matrix[i, j + 1]==0)
                    {
                        matrix[i][j] = 1;
                        CalculateNumberOfWinningMoves(matrix, n+1);
                        count++;
                    }
                }
            }
            return count;
        }
    }
}

