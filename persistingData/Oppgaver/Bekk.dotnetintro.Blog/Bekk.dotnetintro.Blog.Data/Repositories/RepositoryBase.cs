using System.Configuration;
using System.Data.SqlClient;

namespace Blog.dotnetintro.Blog.Data.Repositories
{
    public abstract class RepositoryBase
    {
        protected SqlConnection GetConnection()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["BlogDataConnectionString"].ConnectionString;

            return new SqlConnection(connectionString);
        }
    }
}
