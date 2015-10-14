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
            byte[] expectedResult = new byte[] { 1, 1, 0, 1, 0, 0, 0, 1 };
            CollectionAssert.AreEquivalent(expectedResult, ConvertToBase(209, 2));

        }

        [TestMethod]
        public void TestMethod2()
        {
            byte[] expectedResult = new byte[] { 0, 0, 1, 0, 1, 1, 1, 0 };
            byte[] actualResult = new byte[] { 0, 0, 0, 1, 0, 1, 1, 1 };
            //   byte[] expectedResult = new byte[] { 1, 0, 0, 1, 0, 1, 1, 1, 0 };
            //   byte[] actualResult = new byte[] { 1, 0, 0, 1, 0, 1, 1, 1 };
            CollectionAssert.AreEquivalent(expectedResult, BitwiseLeftShift(actualResult));

        }

        [TestMethod]
        public void TestMethod3()
        {
            byte[] expectedResult = new byte[] { 0, 0, 0, 0, 1, 0, 1, 1 };
            byte[] actualResult = new byte[] { 0, 0, 0, 1, 0, 1, 1, 1 };
            CollectionAssert.AreEquivalent(expectedResult, BitwiseRightShift(actualResult));

        }

        [TestMethod]
        public void TestMethod4()
        {
            byte[] a = new byte[] { 1, 0, 0, 1, 0, 1, 1, 1, 0 };
            byte[] b = new byte[] { 1, 0, 0, 1, 0, 1, 1, 1 };
            CollectionAssert.AreEquivalent(b, BitwiseLessThan(a, b));

        }

        public byte[] ConvertToBase(uint number, uint toBase)
        {
            byte[] result = new byte[0];
            for (int i = 0; number > 0; i++)
            {
                uint difference = number % toBase;
                number = number / toBase;
                result = AddRemainder(ref result, i, difference);

            }
            byte[] reverse = ShowInReverseOrder(result);
            return reverse;

        }

        private static byte[] ShowInReverseOrder(byte[] result)
        {
            var size = result.Length - 1;
            byte[] reverse = new byte[size + 1];
            for (int i = 0; i < result.Length; i++)
            {
                reverse[size] = result[i];
                size--;
            }

            return reverse;
        }

        private static byte[] AddRemainder(ref byte[] result, int i, uint difference)
        {
            Array.Resize(ref result, 8);
            result[i] = (byte)difference;
            return result;
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

        public byte[] BitwiseLeftShift(byte[] number)
        {
            var size = number.Length - 1;
            byte[] left = new byte[8];
            left[size] = 0;
            if (number[0] == 1)
            {
                Array.Resize(ref left, 9);
                for (int i = 0; i <= size; i++)
                    left[i] = number[i];
            }
            else
            {
                for (int i = 0; i <= size - 1; i++)
                    left[i] = number[i + 1];
            }
            return left;
        }

        public byte[] BitwiseRightShift(byte[] number)
        {
            var size = number.Length - 1;
            byte[] right = new byte[8];
            right[size] = 0;
            for (int i = 0; i <= size - 1; i++)
                right[i + 1] = number[i];
            return right;
        }

        public byte[] BitwiseLessThan(byte[] a, byte[] b)
        {
            var size1 = a.Length;
            var size2 = b.Length;
            if (size1 > size2)
                return b;
            else if (size2 > size1)
                return a;

            for (int i = 0; i < size1 - 1; i++)
            {
                if (a[i] > b[i])
                    return b;
                else if (b[i] > a[i])
                    return a;
            }

            return a; //a=b
        }
    }
}
