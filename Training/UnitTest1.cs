using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Training
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            int greutate = 10;
            Assert.AreEqual("DA", CanBeSplit(greutate));
        }

        private string CanBeSplit(int greutate)
        {
            return "";
        }
    }
}
