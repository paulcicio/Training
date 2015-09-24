using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Training
{
    [TestClass]
    public class Coordinates
    {
        [TestMethod]
        public void TestMethod1()
        {
            Assert.AreEqual(0.500000, Math.Round(Heron(0.000000, 0.000000, 1.000000, 1.000000, 0.000000, 1.000000), 6));
        }

        public Double Heron(double x1, double y1, double x2, double y2, double x3, double y3)
        {
            
            double a, b, c;
            a = Math.Sqrt(Math.Pow((x3 - x2), 2) + Math.Pow((y3 - y2), 2));
            b = Math.Sqrt(Math.Pow((x3 - x1),2) + Math.Pow((y3 - y1), 2));
            c = Math.Sqrt(Math.Pow((x2 - x1), 2) + Math.Pow((y2 - y1), 2)); 
            double p = (a + b + c) / 2;
            double A = Math.Sqrt(p * (p - a) * (p - b) * (p - c));
            return A;
        }
    }
}
