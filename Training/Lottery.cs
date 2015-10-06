using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Training
{
    [TestClass]
    public class Lottery
    {
        [TestMethod]
        public void FirstCategory()
        {
            Assert.AreEqual(0.00000007, WinTheLottery(6));        
        }

        [TestMethod]
        public void SecondCategory()
        {
            Assert.AreEqual(0.00001845, WinTheLottery(5));
        }

        [TestMethod]
        public void ThirdCategory()
        {
            Assert.AreEqual(0.00096862, WinTheLottery(4));
        }

        public double WinTheLottery(int n)
        {
            double probability = CalculateCombinations(6, n) * CalculateCombinations(43, 6 - n) / CalculateCombinations(49, 6);
            return Math.Round (probability, 8); 
           
        }

        public double CalculateCombinations(int n, int k)
        {
            return CalculateFactorial(n) / (CalculateFactorial(k) * CalculateFactorial(n - k));

        }

        public double CalculateFactorial(int n)
        {
            if (n == 0)
                return 1;
            double factorial = 1;
            for (int i = 1; i <= n; i++)
            {
                factorial = factorial * i;
            }
            return factorial;
        }
            
    }
}
