using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Bekk.dotnetintro.TDD.Kata1.UnitTest
{
    [TestClass]
    public class StringCalculatorTest
    {
        private StringCalculator _stringCalculator;

        [TestInitialize]
        public void InitializeTest()
        {
            _stringCalculator = new StringCalculator();
        }
        
        [TestMethod]
        public void Add_EmptyString_Return0()
        {
            var result = _stringCalculator.Add(string.Empty);

            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void Add_StringContainsOneNumber_ReturnsTheNumber()
        {
            var result = _stringCalculator.Add("1");

            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void Add_StringContainsOneNumber_ReturnsTheNumber2()
        {
            var result = _stringCalculator.Add("2");

            Assert.AreEqual(2, result);
        }

        [TestMethod]
        public void Add_StringContainsTwoNumbers_ReturnsTheSumOfTheNumbers()
        {
            var result = _stringCalculator.Add("1,2");

            Assert.AreEqual(3, result);
        }

        [TestMethod]
        public void Add_StringContainsThreeNumbers_ReturnsTheSumOfTheNumbers()
        {
            var result = _stringCalculator.Add("1,2,3");

            Assert.AreEqual(6, result);
        }

        [TestMethod]
        public void Add_StringContainsNewLineBetweenNumbers_ReturnsSumOfNmbers()
        {
            var result = _stringCalculator.Add("1\n2,3");

            Assert.AreEqual(6, result);
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void Add_StringContainsBothNewLineAndCommaBetweenNumbers_ThrowsException()
        {
            _stringCalculator.Add("1,\n2");
        }

        [TestMethod]
        public void Add_ChangeDelimiterToSemikolonForStringWithTwoNumbers_ReturnsSumOfNumbers()
        {
            var result = _stringCalculator.Add("//;\n1;2");

            Assert.AreEqual(3, result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Add_ContainsNegativeNumber_ThrowsException()
        {
            _stringCalculator.Add("1,-2");
        }

        [TestMethod]
        public void Add_StringContainsNumberLargerThan1000_NumberLargerThan1000Ignored()
        {
            var result = _stringCalculator.Add("2,1001");

            Assert.AreEqual(2, result);
        }

        [TestMethod]
        public void Add_StringContains1000InAdditionToOtherNumbers_ReturnsTheSumOfAllNumbers()
        {
            var result = _stringCalculator.Add("1000,1,2");

            Assert.AreEqual(1003, result);
        }

        [TestMethod]
        public void Add_DelimiterWithMoreThanOneCharacter_ReturnsSumOfNumbers()
        {
            var result = _stringCalculator.Add("//***\n1***2***3");

            Assert.AreEqual(6, result);
        }

        [TestMethod]
        public void Add_DelimiterWithMoreThanOneCharacter_ReturnsSumOfNumbers2()
        {
            var result = _stringCalculator.Add("//++\n1++2++3");

            Assert.AreEqual(6, result);
        }
    }
}
