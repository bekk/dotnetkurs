using System.Collections.Generic;
using Bekk.dotnetintro.TDD.Blog.Models;

namespace Bekk.dotnetintro.TDD.Blog.Repositories
{
    public class BlogRepository : IBlogRepository
    {
        public IEnumerable<BlogEntry> GetAllBlogEntries()
        {
            return new List<BlogEntry>{new BlogEntry{Id = 1, Title = "My first blogpost", Content = "This is my first blogpost"}};
        }
    }
}