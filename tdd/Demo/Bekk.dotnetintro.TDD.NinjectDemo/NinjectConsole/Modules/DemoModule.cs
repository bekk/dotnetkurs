using Bekk.dotnetintro.TDD.NinjectDemo;
using DemoOutput;
using Ninject.Modules;

namespace Bekk.dotnetintro.TDD.NinjectConsole.Modules
{
    public class DemoModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IOutput>().To<ConsoleOutput>();
            Bind<Logger>().ToSelf();
        }
    }
}
