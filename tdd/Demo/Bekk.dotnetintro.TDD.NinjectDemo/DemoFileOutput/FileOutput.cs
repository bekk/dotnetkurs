using System;
using System.IO;
using Bekk.dotnetintro.TDD.NinjectDemo;

namespace DemoFileOutput
{
    public class FileOutput : IOutput
    {
        public void Write(string message)
        {
            using (var writer = new StreamWriter("output.txt"))
            {
                writer.Write("[Fileoutput] ");
                writer.WriteLine(message);
            }
            Console.WriteLine("Message written to output.txt");
        }
    }
}
