using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Training
{
    [TestClass]
    public class Encryption
    {
        [TestMethod]
        public void TestMethod1()
        {
            Assert.AreEqual("neeaircsciaaanaxiucw", EncryptMessage("nicaieri nu e ca acasa", 4 ));
        }

        private string EncryptMessage(string message, int nrRows)
        {
            Console.WriteLine("Introduceti mesajul original: ");
            string message1 = message.Replace(" ", "");
            int nrChar = message1.Length;
            int nrLines = (int) Math.Ceiling((double) nrChar / nrRows);
            int nrRandomChar = (nrLines * nrRows) - nrChar;
            Random r = new Random();
            int num = r.Next(0, 26);
            char[] litera = new char[nrRandomChar];
            for (int i = 0; i < nrRandomChar; i++)
            {
                litera[i] = (char)('a' + num);
            }

            string[] line = new string[nrLines];
            for (int i = 0; i < nrLines; i++)
            {
                for (int j=0;j<nrChar;j=j+nrLines)
                    if (i + j < nrChar)
                        line[i] += message1[i+j];
            }

            for (int i = nrLines-1; i > 0; i--)
            {
                if (nrRandomChar < 1)
                    break;
                else
                    {
                    line[i] += litera[nrRandomChar - 1];
                    nrRandomChar--;
                     }
            }
          
            string rezultat = null;
            for (int i = 0; i < nrLines; i++)
                rezultat += line[i];
            return rezultat;
        }
    }
}
