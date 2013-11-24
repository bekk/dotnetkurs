using System.Collections.Generic;
using Blog.dotnetintro.Blog.Data.Domain;

namespace Blog.dotnetintro.Blog.Data.Repositories
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
