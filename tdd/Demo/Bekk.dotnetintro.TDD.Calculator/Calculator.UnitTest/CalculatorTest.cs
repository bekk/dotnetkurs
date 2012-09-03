using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Bekk.dotnetintro.TDD.Calculator.UnitTest
{
    [TestClass]
    public class CalculatorTest
    {
        [TestMethod]
        public void Add_TwoNumbers_ReturnSumOfNumbers()
        {
            var calculator = new Calculator(); //arrange

            var result = calculator.Add(1, 2);

            Assert.AreEqual(3, result);
        }
    }
}
