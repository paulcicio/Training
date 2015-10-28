using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CharactersInText
{
    [TestClass]
    public class CharactersInText
    {
        [TestMethod]
        public void CharsInAscendingOrder()
        {
            string actualValue = new string(SortCharactersInOrder("ACBFE"));
            Assert.AreEqual("ABCEF", actualValue);
        }

        [TestMethod]
        public void CharsInDescendingOrder()
        {
            string actualValue = new string(SortCharactersInReverseOrder("ACBFE"));
            Assert.AreEqual("FECBA", actualValue);
        }

        public char[] SortCharactersInOrder(string text)
        {
            char[] splitted = text.ToCharArray();
            int i, j;
            for (i = 0; i < splitted.Length - 1; i++)
                for (j = i + 1; j < splitted.Length; j++)
                    if (splitted[i] > splitted[j])
                    {
                        SwapChar(splitted, i, j);
                    }
            return splitted;
        }

        public char[] SortCharactersInReverseOrder(string text)
        {
            char[] inOrder = SortCharactersInOrder(text);
            Array.Reverse(inOrder);
            return inOrder;
        }

        private static void SwapChar(char[] splitted, int i, int j)
        {
            char aux = splitted[i];
            splitted[i] = splitted[j];
            splitted[j] = aux;            
        }
    }
}
