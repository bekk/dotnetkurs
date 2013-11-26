using System.Collections.Generic;
using System.Net;
using System.Web.Http;
using Bekk.dotnetintro.Blog.ActionResults;
using Bekk.dotnetintro.Blog.Data.Domain;
using Bekk.dotnetintro.Blog.Data.Repositories;

namespace Bekk.dotnetintro.Blog.Controllers
{
    public class BlogPostController : ApiController
    {
        private readonly IBlogPostRepository _repository;

        public BlogPostController(IBlogPostRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<BlogPost> Get()
        {
            return _repository.GetAll();
        }

        [Route(Name = "GetById")]
        public BlogPost Get(int id)
        {
            return _repository.Get(id);
        }

        public IHttpActionResult Post(BlogPost post)
        {
            var newId = _repository.Add(post);
            return new ContentCreatedActionResult(Request, Url.Link("GetById", new {id = newId}));
        }

        public IHttpActionResult Put(int id, BlogPost post)
        {
            _repository.Update(id, post);
            return Content(HttpStatusCode.OK, "updated");
        }

        public IHttpActionResult Delete(int id)
        {
            _repository.Remove(id);
            return Content(HttpStatusCode.OK, id);
        }

        [Route("api/blogpost/{blogpostId:int}/comments")]
        public IEnumerable<Comment> GetComments(int id)
        {
            var blogPost = _repository.Get(id);
            return blogPost.Comments;
        } 
    }
}