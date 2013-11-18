using Bekk.dotnetintro.TDD.CalculatorDemo;
using FluentAssertions;
using NUnit.Framework;

namespace CalculatorDemo.UnitTest
{
    [TestFixture]
    public class CalculatorTest
    {
        [Test]
        public void Add_TwoNumbers_ReturnSumOfNumbers()
        {
            var calculator = new Calculator(); //arrange

            var result = calculator.Add(1, 2);

            result.Should().Be(3);
        }
    }
}
