using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Recursion
{
    [TestClass]
    public class Pascal
    {
        [TestMethod]
        public void PascalTriangleForOneLine()
        {
            var expectedValue = new int [] {1};
            CollectionAssert.AreEquivalent(expectedValue, CalculatePascalTriangle(1));
        }

        [TestMethod]
        public void PascalTriangleForTheSecondLine()
        {
            var expectedValue = new int[] { 1, 1 };
            CollectionAssert.AreEquivalent(expectedValue, CalculatePascalTriangle(2));
        }

        [TestMethod]
        public void PascalTriangleForTheThirdLine()
        {
            var expectedValue = new int[] { 1, 2, 1 };
            CollectionAssert.AreEquivalent(expectedValue, CalculatePascalTriangle(3));
        }

        [TestMethod]
        public void PascalTriangleForTheFourthLine()
        {
            var expectedValue = new int[] { 1, 3, 3, 1 };
            CollectionAssert.AreEquivalent(expectedValue, CalculatePascalTriangle(4));
        }

        [TestMethod]
        public void PascalTriangleForTheFifthLine()
        {
            var expectedValue = new int[] { 1, 4, 6, 4, 1 };
            CollectionAssert.AreEquivalent(expectedValue, CalculatePascalTriangle(5));
        }

        private int[] CalculatePascalTriangle(int numberOfRows)
        {
            if (numberOfRows == 1)            
                return new int[] { 1 };           
            
            var previousLine = CalculatePascalTriangle(numberOfRows - 1);
            return CalculateCurrentLine(numberOfRows, previousLine);
        }

        private static int[] CalculateCurrentLine(int numberOfRows, int[] previousLine)
        {
            var line = InitializeLine(numberOfRows);
            for (int i = 1; i < numberOfRows - 1; i++)
            {
                line[i] = previousLine[i - 1] + previousLine[i];
            }
            return line;
        }

        private static int[] InitializeLine(int numberOfRows)
        {
            int[] line = new int[numberOfRows];
            line[0] = 1;
            line[numberOfRows - 1] = 1;
            return line;
        }
    }
}
