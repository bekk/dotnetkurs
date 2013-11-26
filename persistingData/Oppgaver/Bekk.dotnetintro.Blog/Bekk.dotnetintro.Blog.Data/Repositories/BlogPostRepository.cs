using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using Bekk.dotnetintro.Blog.Data.Domain;
using Bekk.dotnetintro.Blog.Data.Repositories;
using Dapper;

namespace Blog.dotnetintro.Blog.Data.Repositories
{
    public class BlogPostRepository : RepositoryBase, IBlogPostRepository
    {
        public IEnumerable<BlogPost> GetAll()
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                var result = connection.QueryMultiple("SELECT * FROM BlogPost SELECT * FROM Comment");

                return AssembleResult(result);
            }
        }

        public BlogPost Get(int id)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                var result = connection.QueryMultiple("SELECT * FROM BlogPost WHERE Id=@id SELECT * FROM Comment WHERE BlogPostId=@id", new{ id });

                return AssembleResult(result).FirstOrDefault();
            }
        }

        public int Add(BlogPost post)
        {
            const string query = "INSERT INTO BlogPost (Title, Content, Published) VALUES (@Title, @Content, @Published) SELECT CAST(SCOPE_IDENTITY() as int)";
            using (var transaction = new TransactionScope())
            {
                using (var connection = GetConnection())
                {
                    connection.Open();
                    var result = connection.Query<int>(query, new {post.Title, post.Content, post.Published}).First();

                    transaction.Complete();

                    return result;
                }
            }
        }

        public void Update(int id, BlogPost post)
        {
            const string query = "UPDATE BlogPost SET Title=@Title, Content=@Content WHERE Id=@id";
            using (var transaction = new TransactionScope())
            {
                using (var connection = GetConnection())
                {
                    connection.Open();
                    connection.Execute(query, new {post.Title, post.Content, id});
                    transaction.Complete();
                }
            }
        }

        public void Remove(int id)
        {
            using (var transaction = new TransactionScope())
            {
                using (var connection = GetConnection())
                {
                    connection.Open();
                    connection.Execute("DELETE FROM Comment WHERE BlogPostId=@id", new {id});
                    connection.Execute("DELETE FROM BlogPost WHERE Id=@id", new {id});
                }
                transaction.Complete();
            }
        }

        private static IEnumerable<BlogPost> AssembleResult(SqlMapper.GridReader result)
        {
            var blogPosts = result.Read<BlogPost>().ToList();
            var comments = result.Read<Comment>().ToList();

            blogPosts.ForEach(post => post.Comments = comments.FindAll(comment => comment.BlogPostId == post.Id).ToList());
            return blogPosts;
        }
    }
}
