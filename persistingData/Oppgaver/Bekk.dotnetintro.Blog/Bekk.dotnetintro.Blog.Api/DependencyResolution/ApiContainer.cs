using Bekk.dotnetintro.Blog.Data.Repositories;
using StructureMap;

namespace Bekk.dotnetintro.Blog.DependencyResolution
{
    public class ApiContainer
    {
        public static Container Configure()
        {
            return new Container(x => x.For<IBlogPostRepository>().Use<BlogPostRepository>());
        }
    }
}