using System;
using System.IO;
using System.Text;
using Bekk.dotnetintro.TDD.Kata2.View;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Bekk.dotnetintro.TDD.Kata2.UnitTest
{
    [TestClass]
    public class StringCalculatorTest
    {
        [TestMethod]
        public void Contructor_AcceptViewAsParameter()
        {
            ICalculatorView stubbedView = new FakeView();
            var calculator = new StringCalculator(stubbedView);
        }
        
        [TestMethod]
        public void Add_StringWithNumbers_SumOfNumbersDisplayedInView()
        {
            var mockedView = new ConsoleView();
            var mockedBuilder = new StringBuilder();
            TextWriter writer = new StringWriter(mockedBuilder);
            Console.SetOut(writer);
            var calculator = new StringCalculator(mockedView);

            calculator.Add("1,2");

            Assert.AreEqual("3\r\n", mockedBuilder.ToString());
        }
    }

    public class FakeView : ICalculatorView
    {
        public void Display(int number)
        {
            
        }
    }
}
