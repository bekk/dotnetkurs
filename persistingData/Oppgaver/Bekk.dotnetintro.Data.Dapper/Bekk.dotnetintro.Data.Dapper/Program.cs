using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Dapper;

namespace Bekk.dotnetintro.Data.Dapper
{
    class Program
    {
        static void Main(string[] args)
        {
            var query = "SELECT FirstName, LastName, Email FROM Person";
            Console.WriteLine(query);
            ExecuteQuery(query, new {});
            Console.ReadLine();

            query = "SELECT FirstName, LastName, Email FROM Person WHERE Id=@Id";
            Console.WriteLine(query);
            ExecuteQuery(query, new {Id = 1});
            Console.ReadLine();

            const string updateQuery = "UPDATE Person SET Email=@email WHERE Id=@Id";
            ExecuteNonQuery(updateQuery, new { Email = "new@email.com", Id = 1 });
            ExecuteQuery(query, new { Id = 1 });
            Console.ReadLine();
        }

        private static void ExecuteNonQuery(string query, object parameters)
        {
            using (IDbConnection connection = new SqlConnection(GetConnectionString()))
            {
                connection.Open();
                connection.Execute(query, parameters);
            }
        }

        private static void ExecuteQuery(string query, object parameters)
        {
            using (IDbConnection connection = new SqlConnection(GetConnectionString()))
            {
                connection.Open();
                var persons = connection.Query<Person>(query, parameters);

                foreach (var person in persons)
                {
                    Console.WriteLine(string.Format("{0} {1} Email: {2}", person.FirstName, person.LastName, person.Email));
                }
            }
        }

        private static string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["PersonConnectionString"].ConnectionString;
        }

        public class Person
        {
            public int Id { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Email { get; set; }
        }
    }
}
