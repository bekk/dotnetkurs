using System.Collections.Generic;
using Bekk.dotnetintro.Blog.Controllers;
using Bekk.dotnetintro.Blog.Data.Domain;
using Bekk.dotnetintro.Blog.Data.Repositories;
using FluentAssertions;
using Moq;
using NUnit.Framework;

namespace Bekk.dotnetintro.Blog.Api.UnitTest.Controllers
{
    [TestFixture]
    public class BlogPostControllerTest
    {
        [Test]
        public void Get_RepositoryWithBlogPosts_AllBlogPostReturned()
        {
            //arrange
            var repositoryStub = new Mock<IBlogPostRepository>();
            var allBlogPosts = new List<BlogPost>{new BlogPost(), new BlogPost()};
            repositoryStub.Setup(repository => repository.GetAll()).Returns(allBlogPosts);

            var controller = new BlogPostController(repositoryStub.Object);

            //act
            var blogPosts = controller.Get();

            //assert
            blogPosts.ShouldAllBeEquivalentTo(allBlogPosts);
        }

        [Test]
        public void Get_I1dSpecified_BlogPostWithId1Returned()
        {
            //arrange
            var repositoryStub = new Mock<IBlogPostRepository>();
            var blogPost = new BlogPost{Id =1};
            repositoryStub.Setup(repository => repository.Get(1)).Returns(blogPost);

            var controller = new BlogPostController(repositoryStub.Object);

            //act
            var returnedBlogPost = controller.Get(1);

            //assert
            returnedBlogPost.ShouldBeEquivalentTo(blogPost);
        }

        [Test]
        public void Get_I2dSpecified_BlogPostWithId2Returned()
        {
            //arrange
            var repositoryStub = new Mock<IBlogPostRepository>();
            var blogPost = new BlogPost{Id = 2};
            repositoryStub.Setup(repository => repository.Get(2)).Returns(blogPost);

            var controller = new BlogPostController(repositoryStub.Object);

            //act
            var returnedBlogPost = controller.Get(2);

            //assert
            returnedBlogPost.ShouldBeEquivalentTo(blogPost);
        }
    }
}
