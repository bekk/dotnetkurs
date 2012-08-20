using System.Collections.Generic;
using Bekk.dontnetintro.WebApi.Blog.Models;

namespace Bekk.dontnetintro.WebApi.Blog.Repositories
{
    public interface IBlogEntryRepository
    {
        IEnumerable<BlogEntry> Get();
        void Insert(BlogEntry blogEntry);
        void Delete(int id);
    }
}
