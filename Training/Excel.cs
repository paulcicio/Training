using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Training
{
    [TestClass]
    public class Excel
    {
        [TestMethod]
        public void TestMethod1()
        {
            Assert.AreEqual("BF",Columns(58) );
        }

        public string Columns(int n)
        {
            n -= 1;
            int nrLetters;
            string letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string value = "";
            if (n >= 1 && n < 27)
                nrLetters = 1;
            if (n >= 27 && n <= 702)
                nrLetters = 2;
            else
                nrLetters = 3;
            switch (nrLetters)
            {
                case 1:
                    value += letters[n];
                    break;
                case 2:
                    value += letters[n / 26 -1];
                    value += letters[n % 26];
                    break;
            }
                return value;
        }
    }
}
