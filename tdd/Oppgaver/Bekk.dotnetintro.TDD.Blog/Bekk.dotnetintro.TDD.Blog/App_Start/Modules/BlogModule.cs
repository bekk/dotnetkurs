using Bekk.dotnetintro.TDD.Blog.Repositories;
using Ninject.Modules;

namespace Bekk.dotnetintro.TDD.Blog.App_Start.Modules
{
    public class BlogModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IBlogRepository>().To<BlogRepository>();
        }
    }
}