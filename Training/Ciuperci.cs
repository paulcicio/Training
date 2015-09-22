using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Training
{
    [TestClass]
    public class Ciuperci
    {
        [TestMethod]
        public void TestMethod1()
        {   List <int> list = Mushrooms(12, 3);
            Assert.AreEqual(3,list[0]);
            Assert.AreEqual(9, list[1]);
        }

        private List <int> Mushrooms(int n, int x)
        {
            List <int> list = new List <int> ();
            int albe, rosii;
            albe = n / (x + 1);
            rosii = albe * x;
            list.Add(albe);
            list.Add(rosii);
            return list;
            
        }
    }
}
