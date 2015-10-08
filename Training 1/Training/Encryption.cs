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
            int numberRandomChar = (numberOfLines * numberOfColumns) - numberOfChar;
            char[] letter = new char[numberRandomChar];
            for (int i = 0; i < numberRandomChar; i++)
            {
                letter[i] = GenerateRandomChar(numberRandomChar);
            }

            string[] line = CodeMessageOnLines(message1, numberOfColumns);

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
            return encryptedMessage2;
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

        private static string[] CodeMessageOnLines(string message1, int numberOfColumns)
        {
            int numberOfLines = CalculateNumberOfLines(message1, numberOfColumns);
            string[] line = new string[numberOfLines];
           
            for (int i = 0; i < numberOfLines; i++)
            {
                for (int j = 0; j < numberOfColumns; j++)
                {
                    line[i] += message1[j * numberOfLines + i];
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

        private char GenerateRandomChar(int numberRandomChar)
        {
            Random r = new Random();
            int num = r.Next(0, 15);
            return (char)(num);
        }

        private static int CalculateNumberOfLines(string message1, int numberOfColumns)
        {
            int numberOfChar = message1.Length;
            int numberOfLines = (int)Math.Ceiling((double)numberOfChar / numberOfColumns);
            return numberOfLines;
        }

    }
}
