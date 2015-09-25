using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Training
{
    [TestClass]
    public class Square
    {
        [TestMethod]
        public void TestMethod1()
        {
            Assert.AreEqual(4, Pavement (6, 6, 4));
        }

        public double Pavement (double m, double n, double a)
        {
            if (n <= a)
                return Math.Ceiling(m / a);
            else
                return Math.Ceiling(m / a) * 2;
        }
    }
}
