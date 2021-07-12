using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using 

namespace TDD_Calculator.Tests
{
    [TestClass]
    public class MyCalcTests
    {
        [TestMethod]
        public void Sum_null()
        {
            string x = null;
            int expected = 0;
            StringCalculator a = new StringCalculator();
            int actual=a.Add(x);

            Assert.AreEqual(expected, actual);
        }
    }
}
