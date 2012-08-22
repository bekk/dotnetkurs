using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Bekk.dotnetintro.Data.Ado
{
    class Program
    {
        static void Main(string[] args)
        {
            var query = "SELECT FirstName, LastName, Email FROM Person";
            Console.WriteLine(query);
            ExecuteQuery(query, new List<SqlParameter>());
            Console.ReadLine();

            query = "SELECT FirstName, LastName, Email FROM Person WHERE Id=@Id";
            Console.WriteLine(query);
            ExecuteQuery(query, new List<SqlParameter> { new SqlParameter("@id", 1) });
            Console.ReadLine();

            query = "UPDATE Person SET Email=@email WHERE Id=@Id";
            Console.WriteLine(query);
            ExecuteNonQuery(query, new List<SqlParameter> {new SqlParameter("@email","new@email.com"), new SqlParameter("@id", 1) });
            Console.ReadLine();
        }

        private static void ExecuteNonQuery(string query, List<SqlParameter> parameters)
        {
            var connectionString = GetConnectionString();

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = query;
                    parameters.ForEach(parameter => command.Parameters.Add(parameter));

                    var rowsAffected = command.ExecuteNonQuery();
                    Console.WriteLine(string.Format("Rows affected by NonQuery {0}", rowsAffected));
                }
            }
        }

        private static void ExecuteQuery(string query, List<SqlParameter> parameters)
        {
            var connectionString = GetConnectionString();

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = query;
                    parameters.ForEach(parameter => command.Parameters.Add(parameter));

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine(string.Format("{0} {1} Email: {2}", reader[0], reader[1], reader[2]));
                        }
                    }
                }
            }
        }

        private static string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["PersonConnectionString"].ConnectionString;
        }
    }
}
