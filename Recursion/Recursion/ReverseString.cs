using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Recursion
{
    [TestClass]
    public class ReverseString
    {
        [TestMethod]
        public void Reverse()
        {
            Assert.AreEqual("dcba", InverseString("abcd"));
        }

        [TestMethod]
        public void ModifiedChar()
        {
            Assert.AreEqual("mississippi", ChangeCharInString("massassappa", 'a', 'i'));
            Assert.AreEqual("tata", ChangeCharInString("mama", 'm', 't'));
            Assert.AreEqual("cluj", ChangeCharInString("cluj", 'i', 'x'));
        }

        [TestMethod]
        public void EmptyString()
        {
            Assert.AreEqual("", ChangeCharInString("", 'e', 'x'));
        }

       
        private string InverseString(string initialString)
        {
            if (initialString.Length < 1)
                return initialString;
            return initialString[initialString.Length - 1] + InverseString(initialString.Substring(0, initialString.Length - 1));
        }

        private string ChangeCharInString(string initialString, char toChange, char newChar)
        {
            if (initialString.Length < 1)
                return initialString;

            char replacedChar = ChangeChar(initialString[0], toChange, newChar);
            string changedString = ChangeCharInString(initialString.Substring(1, initialString.Length - 1), toChange, newChar);

            return replacedChar + changedString;

        }

        private static char ChangeChar(char firstChar, char toChange, char newChar)
        {
            if (firstChar == toChange)
                firstChar = newChar;
            return firstChar;
        }
    }
}
