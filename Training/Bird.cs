using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Training
{
    [TestClass]
    public class Bird
    {
        [TestMethod]
        public void TestMethod1()
        {
            Assert.AreEqual(4, Distance(8, 2));
        }

        public int Distance(int distance, int speed)
        {
            int timeTrain = (distance / 2) / (2 * speed);
            int distanceBird = timeTrain * (2 * speed);
            return distanceBird;
        }
    }
}
