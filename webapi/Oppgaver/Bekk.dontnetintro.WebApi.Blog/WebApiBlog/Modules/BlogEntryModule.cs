using Bekk.dontnetintro.WebApi.Blog.Repositories;
using Ninject.Modules;

namespace Bekk.dontnetintro.WebApi.Blog.Modules
{
    public class BlogEntryModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IBlogEntryRepository>().To<BlogEntryRepository>();
        }
    }
}