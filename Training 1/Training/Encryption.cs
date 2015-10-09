using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Training
{
    [TestClass]
    public class Encryption
    {
        [TestMethod]
        public void Decrypt()
        {
            var messageEncrypted = EncryptMessage("nicaieri nu e ca acasa", 4);
            Assert.AreEqual("nicaierinuecaacasa", DecryptMessage(messageEncrypted, 4));
        }

        private string EncryptMessage(string message, int numberOfColumns)
        {

            string message1 = message.Replace(" ", "");
            int numberOfChar = message1.Length;
            int numberOfLines = CalculateNumberOfLines(message1, numberOfColumns);
            int numberOfRandomChar = (numberOfLines * numberOfColumns) - numberOfChar;
            char[] letter = new char[numberOfRandomChar];
            for (int i = 0; i < numberOfRandomChar; i++)
                message1 += GenerateRandomChar();
            string encryptedMessage = CodeMessage(message1, numberOfColumns);
            string encryptedMessageWithoutRandomChar = null;
            encryptedMessageWithoutRandomChar = EliminateSpecialChar(encryptedMessage, encryptedMessageWithoutRandomChar);
            return encryptedMessageWithoutRandomChar;
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

        private static string CodeMessage(string message, int numberOfColumns)
        {
            int numberOfLines = CalculateNumberOfLines(message, numberOfColumns);
            string line = string.Empty;

            for (int i = 0; i < numberOfLines; i++)
            {
                for (int j = 0; j < numberOfColumns; j++)
                {
                    if ((j * numberOfLines + i) < message.Length)
                        line += message[j * numberOfLines + i];
                }
            }

            return line;
        }

        private string DecryptMessage(string encryptedMessage, int numberOfColumns)
        {
            string decryptedMessage = null;
            string decryptedMessage2 = null;


            int numberOfLines = CalculateNumberOfLines(encryptedMessage, numberOfColumns);
            for (int i = 0; i < numberOfColumns; i++)
            {
                for (int j = 0; j < numberOfLines; j++)
                {
                    if ((j * numberOfColumns + i) < encryptedMessage.Length)
                        decryptedMessage += encryptedMessage[j * numberOfColumns + i];
                }
            }
            foreach (char c in decryptedMessage)
            {
                if (char.IsLetter(c))
                    decryptedMessage2 += c;
            }
            return decryptedMessage2;
        }

        private char GenerateRandomChar()
        {
            Random r = new Random();
            int num = r.Next(0, 15);
            return (char)(' ' + num);
        }

        private static int CalculateNumberOfLines(string message1, int numberOfColumns)
        {
            int numberOfChar = message1.Length;
            int numberOfLines = (int)Math.Ceiling((double)numberOfChar / numberOfColumns);
            return numberOfLines;
        }

    }
}
