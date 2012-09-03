using System.Web.Mvc;
using Bekk.dotnetintro.TDD.Blog.Repositories;

namespace Bekk.dotnetintro.TDD.Blog.Controllers
{
    public class BlogController : Controller
    {
        protected IBlogRepository Repository { get; set; }
        public BlogController(){}
        public BlogController(IBlogRepository repository)
        {
            Repository = repository;
        }

        public ViewResult Index()
        {
            return View(Repository.GetAllBlogEntries());
        }
    }
}