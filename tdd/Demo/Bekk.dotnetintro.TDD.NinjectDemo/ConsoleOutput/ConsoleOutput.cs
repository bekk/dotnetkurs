using System;
using Bekk.dotnetintro.TDD.NinjectDemo;

namespace DemoOutput 
{
    public class ConsoleOutput : IOutput
    {
        public void Write(string message)
        {
            Console.Write("[ConsoleOutput] ");
            Console.WriteLine(message);
        }
    }
}
