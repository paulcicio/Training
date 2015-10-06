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
            Assert.AreEqual(8, Pavement (8, 4, 2));
        }

        public double Pavement (double m, double n, double a)
        {
            double m1 = Math.Ceiling(m / a);
            double n1 = Math.Ceiling(n / a);
            double rock = m1 * n1;
            return rock; 
        }
    }
}
