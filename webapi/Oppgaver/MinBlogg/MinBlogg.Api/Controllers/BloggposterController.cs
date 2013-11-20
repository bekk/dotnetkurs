using System.Collections.Generic;
using System.Web.Http;

namespace MinBlogg.Api.Controllers
{
    public class BloggposterController : ApiController
    {
        public IEnumerable<string> Get()
        {
            return new[] { "value1", "value2" };
        }

        public void Post(Bloggpost bloggpost)
        {
        }
    }
    
    public class Bloggpost
    {
        public int Id { get; set; }
        public string Tittel { get; set; }
    }
}