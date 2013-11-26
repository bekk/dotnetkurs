using System;
using System.Collections.Generic;

namespace Bekk.dotnetintro.Blog.Data.Domain
{
    public class BlogPost
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string  Content { get; set; }
        public DateTime Published { get; set; }
        public IEnumerable<Comment> Comments { get; set; }
    }
}