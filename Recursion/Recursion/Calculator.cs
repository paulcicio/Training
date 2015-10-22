using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Recursion
{
    [TestClass]
    public class Calculator
    {
        [TestMethod]
        public void OneOperand()
        {
            Assert.AreEqual(5, CalculatePolishExpression("5"));
        }

        [TestMethod]
        public void SimpleExpression()
        {
            Assert.AreEqual(9, CalculatePolishExpression("+ 3 6"));
        }

        [TestMethod]
        public void ComplexExpression()
        {
            Assert.AreEqual(7, CalculatePolishExpression("* 7 - 6 5"));
        }

        [TestMethod]
        public void MoreComplexExpression()
        {
            Assert.AreEqual(1136.25, CalculatePolishExpression("* / * + 56 45 45 3 - 1 0.25"));
        }

        private double CalculatePolishExpression(string operation)
        {
            var splitted = operation.Split(' ');
            var startIndex = 0;
            return CalculatePolishExpression(splitted, ref startIndex);

        }

        private double CalculatePolishExpression(string[] operation, ref int startIndex)
        {
            if (!IsOperator(operation[startIndex]))
                return double.Parse(operation[startIndex++]);

            string anOperator = operation[startIndex++];
            double firstOperand = CalculatePolishExpression(operation, ref startIndex);
            double secondOperand = CalculatePolishExpression(operation, ref startIndex);
            return CalculateOperations(anOperator, firstOperand, secondOperand);
        }

        private bool IsOperator(string v)
        {
            return v == "+" || v == "-" || v == "*" || v == "/";            
        }

        private double CalculateOperations(string anOperator, double first, double second)
        {            
            switch (anOperator)
            {
                case ("+"):
                    return first + second;
                case ("-"):
                    return first - second; 
                case ("*"):
                    return first * second; 
                case ("/"): 
                    return first / second;
            }
            return double.Parse(anOperator);
        }
    }
}
