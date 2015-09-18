using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Training
{
    [TestClass]
    public class Pepene
    {
        [TestMethod]
        public void ValoareNegativa()
        {
            Assert.AreEqual("Invalid", CanBeSplit(-2));
        }

        [TestMethod]
        public void Par()
        {
            Assert.AreEqual("DA", CanBeSplit(10));
        }

        [TestMethod]
        public void Impar()
        {
            Assert.AreEqual("NU", CanBeSplit(9));
        }

        private string CanBeSplit(int greutate)
        {
            if (greutate <= 0)
                return "Invalid";
            return (greutate % 2 == 0) ? "DA" : "NU";
        }
    }
}
