using Bekk.dotnetintro.WebApi.Persons.Repositories;
using Ninject.Modules;

namespace Bekk.dotnetintro.WebApi.Persons.IoC.Modules
{
    public class PersonsModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IPersonRepository>().To<PersonRepository>();
        }
    }
}