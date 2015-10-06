using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Training
{
    [TestClass]
    public class Goat
    {
        [TestMethod]
        public void TestMethod1()
        {
            Assert.AreEqual(60, Goats(10, 10, 20, 20, 15));
        }

        private double Goats(double x, double y, double z, double q, double w)
        {
            double daily = z / (x * y);
            double hay = daily * q * w;
            return hay; 
        }
    }
}
