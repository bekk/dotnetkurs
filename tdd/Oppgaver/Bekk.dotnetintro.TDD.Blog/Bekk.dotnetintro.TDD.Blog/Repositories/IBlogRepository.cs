using System.Collections.Generic;
using Bekk.dotnetintro.TDD.Blog.Models;

namespace Bekk.dotnetintro.TDD.Blog.Repositories
{
    public interface IBlogRepository
    {
        IEnumerable<BlogEntry> GetAllBlogEntries();
    }
}