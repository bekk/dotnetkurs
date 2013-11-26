using System.Collections.Generic;
using Bekk.dotnetintro.Blog.Data.Domain;

namespace Bekk.dotnetintro.Blog.Data.Repositories
{
    public interface IBlogPostRepository
    {
        IEnumerable<BlogPost> GetAll();
        BlogPost Get(int id);
        int Add(BlogPost post);
        void Update(int id, BlogPost post);
        void Remove(int id);
    }
}
