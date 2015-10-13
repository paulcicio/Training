using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Binary_operations
{
    [TestClass]
    public class Base2operations
    {
        [TestMethod]
        public void TestMethod1()
        {
            byte[] expectedResult = new byte[] {1, 1, 0, 1, 0, 0, 0, 1 };
                
            Assert.AreEqual(expectedResult, ConvertToBase(209, 2));
        }

        public byte [] ConvertToBase(uint number, uint toBase)
        {
            byte [] result = new byte[0];
            for (int i=0;  number > 0; i++)
            {
                uint difference = number % toBase;
                number = number / toBase;
                Array.Resize(ref result, 8);
                result[i] = (byte) difference;
                

            }
            var size = result.Length-1;
            byte[] reverse = new byte[size+1];
            for (int i = 0; i < result.Length; i++)
            {
                reverse[size] = result[i];
                size--;
            }
            return reverse;

        }

        public byte BitwiseAND(byte a, byte b)
        {
            if ((a == 1) && (b == 1))
                return 1;
            else
                return 0;
        }

        public byte BitwiseOR(byte a, byte b)
        {
            if ((a == 0) && (b == 0))
                return 0;
            else
                return 1;
        }

        public byte BitwiseNOT(byte a)
        {
            if (a == 0)
                return 1;
            else
                return 0;

        }

        public byte BitwiseXOR(byte a, byte b)
        {
            if ((a == 0) && (b == 0) || ((a == 1) && (b == 1)))
                return 0;
            else
                return 1;
        }

    }
}
