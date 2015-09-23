using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Training
{
    [TestClass]
    public class Bank
    {
        [TestMethod]
        public void TestMethod1()
        {
            Assert.AreEqual(337.50, Bankrate(20000, 60, 15, 60));
        }

        public double Bankrate(double ammount, double term, double interest, double x)
        {
            double capital = ammount / term;
            
                double rateofinterest = (interest / 12/100) * (ammount - (x-1) * capital);

                double rate = capital + rateofinterest;
                return rate;
            
        }
    }
}
