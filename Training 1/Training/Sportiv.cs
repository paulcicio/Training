using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Training
{
    [TestClass]
    public class Sportiv
    {
        [TestMethod]
        public void Correct()
        {
            Assert.AreEqual(20, Gauss(4));
        }

        [TestMethod]
        public void Invalid()
        {
            Assert.AreEqual(-1, Gauss(-1));
        }

        private int Gauss(int n)
        {
            if (n < 0)
                return -1;
            else 
                return n * (n + 1);
        }
    }
}
