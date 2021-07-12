using NUnit.Framework;
using System;
using TDD_Calculator;

namespace TDD_Calcluator.tests
{
    public class CalculatorTests
    {
        [Test]
        public void CalculatorTests_Sum_Null_Zero()
        {
            string testStringNumbers ="";
            int expected = 0;
            StringCalculator a = new StringCalculator();
            int actual = a.Add(testStringNumbers);
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void CalculatorTests_Sum_Five_Five()
        {
            string testStringNumbers = "5";
            int expected = 5;
            StringCalculator a = new StringCalculator();
            int actual = a.Add(testStringNumbers);
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void CalculatorTests_Sum_testStringNumbers_Eleven()
        {
            string testStringNumbers = "1,2,3,5";
            int expected = 11;
            StringCalculator a = new StringCalculator();
            int actual = a.Add(testStringNumbers);
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void CalculatorTests_Sum_testStringNumbersWithIndent_Six()
        {
            string testStringNumbers = "1\n2,3";
            int expected = 6;
            StringCalculator a = new StringCalculator();
            int actual = a.Add(testStringNumbers);
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void CalculatorTests_Sum_testStringNumbersWithSpliters_Six()
        {
            string testStringNumbers = "//;\n1;2;3";
            int expected = 6;
            StringCalculator a = new StringCalculator();
            int actual = a.Add(testStringNumbers);
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void CalculatorTests_Sum_testStringNegativeNumbers_NegativesNotAllowed()
        {
            string testStringNumbers = "//;\n1;-1;-4;2;3";
            Exception expected = new Exception($"negatives not allowed:{-1},{-4}");
            StringCalculator a = new StringCalculator();
            var actual = Assert.Catch(() => a.Add(testStringNumbers));
            Assert.AreEqual(expected.Message, actual.Message);
        }
        [Test]
        public void CalculatorTests_Sum_GetCalledCountThree_Three()
        {
            StringCalculator test = new StringCalculator();
            test.Add("5");
            test.Add("5");
            test.Add("5");
            int expected = 3;
            int actual = test.GetCalledCount();
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void CalculatorTests_Sum_GetCalledCountThreeWithEvent_Three()
        {
            StringCalculator test = new StringCalculator();
            test.Add("5");
            test.Add("5");
            test.Add("5");
            int expected = 3;
            test.Some("s", 1);
            int actual = test.GetCalledCount();
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void CalculatorTests_Sum_testStringNumbersWithoutThousands_Three()
        {
            string testStringNumbers = "//;\n1000;2000;3";
            int expected = 3;
            StringCalculator a = new StringCalculator();
            int actual = a.Add(testStringNumbers);
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void CalculatorTests_Sum_testStringNumbersWith—ertainSeparators_Six()
        {
            string testStringNumbers = "//***\n1***2***3";
            int expected = 6;
            StringCalculator a = new StringCalculator();
            int actual = a.Add(testStringNumbers);
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void CalculatorTests_Sum_testStringNumbersWithDifSeparators_Six()
        {
            string testStringNumbers = "//*%\n1*2%3";
            int expected = 6;
            StringCalculator a = new StringCalculator();
            int actual = a.Add(testStringNumbers);
            Assert.AreEqual(expected, actual);
        }
    }
}