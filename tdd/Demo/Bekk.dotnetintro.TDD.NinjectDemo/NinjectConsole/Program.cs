using System;
using Bekk.dotnetintro.TDD.NinjectConsole.Modules;
using Bekk.dotnetintro.TDD.NinjectDemo;
using Ninject;

namespace Bekk.dotnetintro.TDD.NinjectConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            IKernel ninjectKernel = new StandardKernel(new DemoModule());
            var logger = ninjectKernel.Get<Logger>();

            logger.Start();

            Console.ReadLine();
        }
    }
}
