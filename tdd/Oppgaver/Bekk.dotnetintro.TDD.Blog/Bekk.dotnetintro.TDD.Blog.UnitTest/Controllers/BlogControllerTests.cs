using System.Collections.Generic;
using System.Web.Mvc;
using Bekk.dotnetintro.TDD.Blog.Controllers;
using Bekk.dotnetintro.TDD.Blog.Models;
using Bekk.dotnetintro.TDD.Blog.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;

namespace Bekk.dotnetintro.TDD.Blog.UnitTest.Controllers
{
    [TestClass]
    public class BlogControllerTests
    {
        [TestMethod]
        public void Index_GetAllBlogEntriesCalled()
        {
            //arrange
            var mockedRepository = MockRepository.GenerateMock<IBlogRepository>();
            var blogController = new BlogController(mockedRepository);
            
            //act
            blogController.Index();

            //assert
            mockedRepository.AssertWasCalled(blogRepository => blogRepository.GetAllBlogEntries());
        }

        [TestMethod]
        public void Index_OneBlogEntryInRepository_BlogEntryReturnedInViewResult()
        {
            //arrange
            var stubbedRepository = MockRepository.GenerateStub<IBlogRepository>();
            var blogEntry = new BlogEntry();
            stubbedRepository.Stub(repository => repository.GetAllBlogEntries()).Return(new List<BlogEntry> {blogEntry});
            
            var blogController = new BlogController(stubbedRepository);

            //act
            ViewResult viewResult = blogController.Index();
            var blogEntries = viewResult.ViewData.Model as List<BlogEntry>;

            //assert
            Assert.AreEqual(1, blogEntries.Count);
        }
    }
}
