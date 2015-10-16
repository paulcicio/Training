using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Binary_operations
{
    [TestClass]
    public class Base2operations
    {
        [TestMethod]
        public void BaseConversion()
        {

            byte[] expectedResult = new byte[] { 1, 1, 0, 1, 0, 0, 0, 1 };
            CollectionAssert.AreEquivalent(expectedResult, ConvertToBase(209, 2));

        }

        [TestMethod]
        public void LeftShift()
        {
            byte[] expectedResult = new byte[] { 0, 0, 1, 0, 1, 1, 1, 0 };
            byte[] actualResult = new byte[] { 0, 0, 0, 1, 0, 1, 1, 1 };
            //   byte[] expectedResult = new byte[] { 1, 0, 0, 1, 0, 1, 1, 1, 0 };
            //   byte[] actualResult = new byte[] { 1, 0, 0, 1, 0, 1, 1, 1 };
            CollectionAssert.AreEquivalent(expectedResult, BitwiseLeftShift(actualResult));

        }

        [TestMethod]
        public void RightShift()
        {
            byte[] expectedResult = new byte[] { 0, 0, 0, 0, 1, 0, 1, 1 };
            byte[] actualResult = new byte[] { 0, 0, 0, 1, 0, 1, 1, 1 };
            CollectionAssert.AreEquivalent(expectedResult, BitwiseRightShift(actualResult));

        }

        [TestMethod]
        public void LessThan()
        {
            byte[] a = new byte[] { 1, 0, 0, 1, 0, 1, 1, 1, 0 };
            byte[] b = new byte[] { 1, 0, 0, 1, 0, 1, 1, 1 };
            Assert.AreEqual(false, BitwiseLessThan(a, b));

        }

        [TestMethod]
        public void GreaterThan()
        {
            byte[] a = new byte[] { 1, 1, 0, 1, 0, 1, 1, 1, 0 };
            byte[] b = new byte[] { 1, 0, 0, 1, 0, 1, 1, 1 };
            Assert.AreEqual(true, BitwiseGreaterThan(a, b));

        }

        [TestMethod]
        public void Equal()
        {
            byte[] a = new byte[] { 1, 0, 0, 1, 0, 1, 1, 1, 0 };
            byte[] b = new byte[] { 1, 0, 0, 1, 0, 1, 1, 1 };
            Assert.AreEqual(false, BitwiseEqual(a, b));

        }

        [TestMethod]
        public void NotEqual()
        {
            byte[] a = new byte[] { 1, 0, 0, 1, 0, 1, 1, 1, 0 };
            byte[] b = new byte[] { 1, 0, 0, 1, 0, 1, 1, 1 };
            Assert.AreEqual(true, BitwiseNotEqual(a, b));

        }

        [TestMethod]
        public void Addition()
        {
            byte[] a = new byte[] { 0, 0, 0, 0, 1, 0, 0, 0 };
            byte[] b = new byte[] { 0, 0, 0, 0, 1, 0, 0, 0 };
            byte[] expectedValue = new byte[] { 0, 0, 0, 1, 0, 0, 0, 0 };
            CollectionAssert.AreEquivalent(expectedValue, BitwiseAddition(a, b));

        }

        [TestMethod]
        public void Multiplication()
        {
            byte[] a = new byte[] { 0, 0, 0, 0, 1, 0, 0, 0 };
            byte[] b = new byte[] { 0, 0, 0, 0, 0, 0, 1, 1 };
            byte[] expectedValue = new byte[] { 0, 0, 0, 1, 1, 0, 0, 0 };
            CollectionAssert.AreEquivalent(expectedValue, BitwiseMultiplication(a, b));

        }

        [TestMethod]
        public void Substraction()
        {
            byte[] a = new byte[] { 0, 0, 1, 0, 0, 1, 0, 1 };
            byte[] b = new byte[] { 0, 0, 0, 1, 0, 0, 0, 1 };
            byte[] expectedValue = new byte[] { 0, 0, 0, 1, 0, 1, 0, 0 };
            CollectionAssert.AreEquivalent(expectedValue, BitwiseSubstraction(a, b));

        }

        [TestMethod]
        public void Division()
        {
            byte[] a = new byte[] { 0, 0, 1, 0, 1, 0, 1, 0 };
            byte[] b = new byte[] { 0, 0, 0, 0, 0, 1, 1, 0 };
            byte[] expectedValue = new byte[] { 0, 0, 0, 0, 0, 1, 1, 1 };
            byte[] actualValue = BitwiseDivision(a, b);
            CollectionAssert.AreEquivalent(expectedValue, actualValue);

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


        public byte[] BitwiseAddition(byte[] x, byte[] y)
        {
            int max = MaxLength(x, y);
            byte[] result = new byte[max];
            uint carry = 0;

            for (int i = max - 1; i >= 0; i--)
            {
                if (x[i] == 1 && y[i] == 1)
                {
                    if (carry == 1)
                        result[i] = 1;
                    else
                        result[i] = 0;
                    carry = 1;
                }
                else if (x[i] == 0 && y[i] == 0)
                {
                    if (carry == 1)
                        result[i] = 1;
                    else
                    {
                        result[i] = 0;

                    }
                    carry = 0;
                }
                else
                {
                    if (carry == 1)
                        result[i] = 0;
                    else
                    {
                        result[i] = 1;
                        carry = 0;
                    }

                }
            }
            if (carry == 1)
            {
                Array.Resize(ref result, max + 1);
                result[0] = 1;
            }
            return result;
        }

        public byte[] BitwiseSubstraction(byte[] x, byte[] y)
        {
            int max = MaxLength(x, y);
            byte[] result = new byte[max];
            uint borrow = 0;

            for (int i = max - 1; i >= 0; i--)
            {
                if (x[i] == 0 && y[i] == 1)
                {
                //    if (borrow == 1)
                  //  {
                    //    result[i] = 0;
                   // }
                   // else
                        result[i] = 1;
                    borrow = 1;

                }
                else if (x[i] == 1 && y[i] == 0)
                {
                    if (borrow == 1)
                        result[i] = 0;
                    else
                    {
                        result[i] = 1;
                    }
                    borrow = 0;

                }
                else if (x[i] == 1 && y[i] == 1)
                {
                    if (borrow == 1)
                    {
                        result[i] = 1;
                    }
                    else
                    {
                        result[i] = 0;
                    }
                    borrow = 0;
                }

                else if ((x[i] == 0 && y[i] == 0))
                {
                   // if (borrow == 1)
                   // {
                    //    result[i] = 1;
                   // }
                   // else
                    {
                        result[i] = 0;
                   //     borrow = 0;
                    }
                 //   borrow = 0;

                }


            }
            return result;
        }

        public int ConverseToDecimal(byte[] number, uint fromBase)
        {
            int result = 0;
            int power = 0;
            for (int i = number.Length - 1; i >= 0; i--)
            {
                result = (int)(result + number[i] * Math.Pow(fromBase, power));
                power++;
            }

            return result;
        }

        public byte[] BitwiseMultiplication(byte[] x, byte[] y)
        {
            int multiplier = ConverseToDecimal(y, 2);
            byte[] result = new byte[8];
            for (int i = 0; i < multiplier; i++)
            {

                result = BitwiseAddition(result, BitwiseAddition(x, x));
            }
            return result;
        }

        public byte[] BitwiseDivision(byte[] x, byte[] y)
        {
            uint iterations = 0;
            while ((BitwiseLessThan(y, x) || (BitwiseEqual(x, y)==true)))
            {
               
                x = BitwiseSubstraction(x, y);
                iterations++;
                
            }
            return ConvertToBase(iterations, 2);
            
        }

        private static int MaxLength(byte[] x, byte[] y)
        {
            var size1 = x.Length;
            var size2 = y.Length;
            if (size1 >= size2)
                return size1;
            else return size2;
        }

        public bool BitwiseLessThan(byte[] a, byte[] b)
        {
            var size1 = a.Length;
            var size2 = b.Length;
            if (size1 > size2)
                return false;

            for (int i = 0; i < size1 - 1; i++)
            {
                if (a[i] >= b[i])
                    return false;

            }

            return true;
        }

        public bool BitwiseGreaterThan(byte[] a, byte[] b)
        {

            return (!BitwiseLessThan(a, b)) ? true : false;

        }

        public bool BitwiseEqual(byte[] a, byte[] b)
        {
            return (BitwiseLessThan(b, a) == true && BitwiseLessThan(a, b) == true) ? true : false;
        }

        public bool BitwiseNotEqual(byte[] a, byte[] b)
        {
            return (BitwiseLessThan(b, a) != BitwiseLessThan(a, b)) ? true : false;
        }
    }
}
