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
            Assert.AreEqual(92, CoverChessBoard());
        }

        private int CoverChessBoard()
        { int numberOfSquares =0;
            for (int i = 1; i <= 8; i++)
            {
                numberOfSquares += (int) Math.Pow(Math.Truncate((double) (8 / i)), 2);
            }
            return numberOfSquares;
        }
    }
}
