using NUnit.Framework;
using TDD_Calculator;

namespace TDD_Calcluator.tests
{
    public class Tests
    {     
        [Test]
        public void Sum_null()
        {
            string x ="";
            int expected = 0;
            StringCalculator a = new StringCalculator();
            int actual = a.Add(x);
            Assert.AreEqual(expected, actual);
            Assert.Pass();
        }
        [Test]
        public void Sum_OneNumber()
        {
            string x = "5";
            int expected = 5;
            StringCalculator a = new StringCalculator();
            int actual = a.Add(x);
            Assert.AreEqual(expected, actual);
            Assert.Pass();
        }
        [Test]
        public void Sum_TwoNumbers()
        {
            string x = "1,2,3,5";
            int expected = 11;
            StringCalculator a = new StringCalculator();
            int actual = a.Add(x);
            Assert.AreEqual(expected, actual);
            Assert.Pass();
        }
        [Test]
        public void Sum_SumWith_N()
        {
            string x = "1\n2,3";
            int expected = 6;
            StringCalculator a = new StringCalculator();
            int actual = a.Add(x);
            Assert.AreEqual(expected, actual);
            Assert.Pass();
        }
        [Test]
        public void Sum_SumWith_DifferentSplit()
        {
            string x = "//;\n1;2;3";
            int expected = 6;
            StringCalculator a = new StringCalculator();
            int actual = a.Add(x);
            Assert.AreEqual(expected, actual);
            Assert.Pass();
        }
        [Test]
        public void Sum_SumWith_NegativeNum()
        {
            string x = "//;\n1;-1;-4;2;3";
            string expected = "negatives not allowed: -1 -4";
            StringCalculator a = new StringCalculator();
            int actual = a.Add(x);
            Assert.AreEqual(expected, actual);
            Assert.Pass();
        }
    }
}