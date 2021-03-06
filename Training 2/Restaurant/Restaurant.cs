﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Restaurant
{
    [TestClass]
    public class Restaurant
    {
        [TestMethod]
        public void TestMethod1()
        {
            Assert.AreEqual(3960, CalculateLeastCommonMultiple(1980, 88));
        }


        private int CalculateLeastCommonMultiple(int x, int y)
        {
            int cmmmc = (x * y) / CalculateGreatestCommonDivisor(x, y);
            return cmmmc;
        }


        private int CalculateGreatestCommonDivisor(int a, int b)
        {
            int difference = (a % b);
            while (difference != 0)
            {
                a = b;
                b = difference;
                difference = a % b;
            }
            return b;
        }
    }
}

