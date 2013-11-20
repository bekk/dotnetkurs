using Bekk.dotnetintro.TDD.CalculatorDemo;
using FluentAssertions;
using NUnit.Framework;

namespace CalculatorDemo.UnitTest
{
    [TestFixture]
    public class CalculatorTest
    {
        private Calculator _calculator;

        [SetUp]
        public void InitTest()
        {
            _calculator = new Calculator();
        }

        [Test]

        public void Add_TwoNumbers_ReturnSumOfNumbers()
        {
            var calculator = new Calculator(); //arrange

            var result = calculator.Add(1, 2);

            result.Should().Be(3);
        }

        [Test]
        public void Subtract_6From10_Return4()
        {
            var calculator = new Calculator();

            var result = calculator.Subtract(6, 10);

            result.Should().Be(4);
        }

        [Test]
        public void Subtra_3From8_Return5()
        {
            var calculator = new Calculator();

            var result = calculator.Subtract(3, 8);

            result.Should().Be(5)
        }
    }
}
