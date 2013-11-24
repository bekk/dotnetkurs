using System.Collections.Generic;
using System.Linq;
using Blog.dotnetintro.Blog.Data.Domain;

namespace Blog.dotnetintro.Blog.Data.Repositories
{
    public class BlogPostRepository : IBlogPostRepository
    {
        public IEnumerable<BlogPost> GetAll()
        {
            return Enumerable.Empty<BlogPost>();
        }

        public BlogPost Get(int id)
        {
            return new BlogPost();
        }

        public int Add(BlogPost post)
        {
            return 1;
        }

        public void Update(int id, BlogPost post)
        {
            
        }

        public void Remove(int id)
        {
            
        }
    }
}
