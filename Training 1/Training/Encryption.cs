using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Training
{
    [TestClass]
    public class Encryption
    {
        [TestMethod]
        public void Encrypt()
        {
            Assert.AreEqual("neeaircsciaaanaiuc", EncryptMessage("nicaieri nu e ca acasa", 4, false));
        }

        [TestMethod]
        public void Decrypt()
        {
            Assert.AreEqual("nicaierinuecaacasa", DecryptMessage(EncryptMessage("nicaieri nu e ca acasa", 4, true), 4, 2));
        }

        private string EncryptMessage(string message, int numberOfRows, bool withSpecialChar)
        {

            string message1 = message.Replace(" ", "");
            int numberOfChar = message1.Length;
            int numberOfLines = (int)Math.Ceiling((double)numberOfChar / numberOfRows);
            int numberRandomChar = (numberOfLines * numberOfRows) - numberOfChar;
            char[] letter = new char[numberRandomChar];
            for (int i = 0; i < numberRandomChar; i++)
            {
                letter[i] = GenerateRandomChar(numberRandomChar);
            }

            string[] line = CodeMessageOnLines(message1, numberOfChar, numberOfLines);

            for (int i = numberOfLines - 1; i > 0; i--)
            {
                if (numberRandomChar < 1)
                    break;
                else
                {
                    line[i] += letter[numberRandomChar - 1];
                    numberRandomChar--;
                }
            }

            string encryptedMessage = null;
            string encryptedMessage2 = null;
            for (int i = 0; i < numberOfLines; i++)
            {
                encryptedMessage += line[i];
            }

            encryptedMessage2 = EliminateSpecialChar(encryptedMessage, encryptedMessage2);
            if (withSpecialChar)
                return encryptedMessage2;
            else return encryptedMessage;
        }

        private static string EliminateSpecialChar(string encryptedMessage, string encryptedMessage2)
        {
            foreach (char c in encryptedMessage)
            {
                if (char.IsLetter(c))
                    encryptedMessage2 += c;
            }

            return encryptedMessage;
        }

        private static string[] CodeMessageOnLines(string message1, int numberOfChar, int numberOfLines)
        {
            string[] line = new string[numberOfLines];
            for (int i = 0; i < numberOfLines; i++)
            {
                for (int j = 0; j < numberOfChar; j = j + numberOfLines)
                {
                    if (i + j < numberOfChar)
                        line[i] += message1[i + j];
                }
            }

            return line;
        }

        private string DecryptMessage(string encryptedMessage, int numberOfRows, int numberRandomChar)
        {
            string decryptedMessage = null;
            string decryptedMessage2 = null;
            for (int i = 0; i < numberOfRows; i++)
            {
                for (int j = i; j < encryptedMessage.Length; j = j + numberOfRows)
                {
                    if (j < encryptedMessage.Length)
                        decryptedMessage += encryptedMessage[j];
                }
            }
            decryptedMessage2 = decryptedMessage.Substring(0, encryptedMessage.Length - numberRandomChar);
            return decryptedMessage2;
        }

        private char GenerateRandomChar(int numberRandomChar)
        {
            Random r = new Random();
            int num = r.Next(0, 15);
            return (char)(num);
        }
    }
}
