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

        public string ConvertToRomanNumerals(uint arabNumber)
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

        public string BreakDownTheNumber(uint arabNumber)
        {
            string finalResult, stringM, stringCM, stringD, stringCD, stringC, stringXC, stringL, stringXL, stringX, stringIX, stringV, stringIV, stringI;
            uint differenceCM, differenceM, differenceD, differenceCD, differenceC, differenceXC, differenceL, differenceXL, differenceX, differenceIX, differenceV, differenceIV, differenceI;
            differenceM = arabNumber % 1000;
            stringM = ConvertToRomanNumerals(arabNumber - differenceM);
            arabNumber = differenceM;
            differenceCM = arabNumber % 900;
            stringCM = ConvertToRomanNumerals(arabNumber - differenceCM);
            arabNumber = differenceCM;
            differenceD = arabNumber % 500;
            stringD = ConvertToRomanNumerals(arabNumber - differenceD);
            arabNumber = differenceD;
            differenceCD = arabNumber % 400;
            stringCD = ConvertToRomanNumerals(arabNumber - differenceCD);
            arabNumber = differenceCD;
            differenceC = arabNumber % 100;
            stringC = ConvertToRomanNumerals(arabNumber - differenceC);
            arabNumber = differenceC;
            differenceXC = arabNumber % 90;
            stringXC = ConvertToRomanNumerals(arabNumber - differenceXC);
            arabNumber = differenceXC;
            differenceL = arabNumber % 50;
            stringL = ConvertToRomanNumerals(arabNumber - differenceL);
            arabNumber = differenceL;
            differenceXL = arabNumber % 40;
            stringXL = ConvertToRomanNumerals(arabNumber - differenceXL);
            arabNumber = differenceXL;
            differenceX = arabNumber % 10;
            stringX = ConvertToRomanNumerals(arabNumber - differenceX);
            arabNumber = differenceX;
            differenceIX = arabNumber % 9;
            stringIX = ConvertToRomanNumerals(arabNumber - differenceIX);
            arabNumber = differenceIX;
            differenceV = arabNumber % 5;
            stringV = ConvertToRomanNumerals(arabNumber - differenceV);
            arabNumber = differenceV;
            differenceIV = arabNumber % 4;
            stringIV = ConvertToRomanNumerals(arabNumber - differenceIV);
            arabNumber = differenceIV;
            differenceI = arabNumber % 1;
            stringI = ConvertToRomanNumerals(arabNumber - differenceI);
            arabNumber = differenceI;
            finalResult = stringM + stringCM + stringD + stringCD + stringC + stringXC + stringL + stringXL + stringX + stringIX + stringV + stringIV + stringI;
            return finalResult;
        }

    }
}

