using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Sorting_Algorithms
{
    [TestClass]
    public class Roman_Numerals
    {
        [TestMethod]
        public void SimpleNumber()
        {
            Assert.AreEqual("IV", ConvertToRomanNumerals(4));
            Assert.AreEqual("V", ConvertToRomanNumerals(5));
            Assert.AreEqual("IX", ConvertToRomanNumerals(9));
            Assert.AreEqual("XV", ConvertToRomanNumerals(15));
            Assert.AreEqual("XXX", ConvertToRomanNumerals(30));
            Assert.AreEqual("XLI", ConvertToRomanNumerals(41));
            Assert.AreEqual("XLV", ConvertToRomanNumerals(45));
        }

        [TestMethod]
        public void Complex()
        {
            Assert.AreEqual("XXXIX", ConvertToRomanNumerals(39));
            Assert.AreEqual("XCIX", ConvertToRomanNumerals(99));
            Assert.AreEqual("CMXCIX", ConvertToRomanNumerals(999));
            Assert.AreEqual("MCMXIX", ConvertToRomanNumerals(1919));
        }

        public string ConvertToRomanNumerals(int arabNumber)
        {
            switch (arabNumber)
            {
                case 0:
                    {                        
                        return "";                        
                    }
                case 1:
                    return "I";
                case 4:
                    return "IV";
                case 5:
                    return "V";
                case 9:
                    return "IX";
                case 10:
                    return "X";
                case 40:
                    return "XL";
                case 50:
                    return "L";
                case 90:
                    return "XC";
                case 100:
                    return "C";
                case 400:
                    return "CD";
                case 500:
                    return "D";
                case 900:
                    return "CM";
                case 1000:
                    return "M";
                default:
                    return BreakDownTheNumber(arabNumber);

            }

        }

        public string BreakDownTheNumber(int arabNumber)
        {
            int[] numbersForDivision = { 1000, 900, 500, 400, 100, 90, 50, 40, 10, 9, 5, 4, 1 };
            int difference, quotient;
            string partialResult, finalResult="";
            for (int i=0; i < numbersForDivision.Length && arabNumber > 0; i++)
            {
                difference = arabNumber % numbersForDivision[i];
                if (difference == 0) //For arabNumber=30
                {
                    quotient = arabNumber / numbersForDivision[i];
                    partialResult = ConvertToRomanNumerals(arabNumber / quotient);
                    for (int j = 0; j < quotient; j++)
                    {
                        finalResult += partialResult;
                        arabNumber -= numbersForDivision[i];
                    }
                }
                else
                {
                    partialResult = ConvertToRomanNumerals(arabNumber - difference);
                    arabNumber = difference;
                    finalResult += partialResult;
                }
            }
           
            return finalResult;
        }

    }
}

