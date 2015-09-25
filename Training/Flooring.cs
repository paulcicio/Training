using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Training
{
    [TestClass]
    public class Flooring
    {
        [TestMethod]
        public void TestMethod1()
        {
            Assert.AreEqual(6, Parquet(6, 5, 2, 3));
        }

        public int Parquet(int m, int n, int a, int b)
        {
            double area = m * n + 0.15 * (m * n);
            double floor = Math.Ceiling(area / (a * b));
            return Convert.ToInt32(floor);

        }
    }
}
