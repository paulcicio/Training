using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Chessboard
{
    [TestClass]
    public class Chess
    {
        [TestMethod]
        public void TestMethod1()
        {
            Assert.AreEqual(92, CoverChessBoard(8));
        }

        private int CoverChessBoard(int m)
        {
            int numberOfSquares = 0;
            for (int i = 1; i <= 8; i++)
            {
                numberOfSquares += (int)Math.Pow(Math.Truncate((double)(8 / i)), 2);
            }
            return numberOfSquares;
        }
    }
}
