using System;

namespace Bekk.dotnetintro.TDD.Kata2.View
{
    public class ConsoleView : ICalculatorView
    {
        public void Display(int number)
        {
            Console.WriteLine(number);
        }
    }
}
