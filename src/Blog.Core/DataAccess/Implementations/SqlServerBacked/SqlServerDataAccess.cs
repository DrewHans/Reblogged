using System.Collections.Generic;
using System.Data.SqlClient;

namespace Blog.Core
{
    public class SqlServerDataAccess : ISqlServerDataAccess
    {
        public int ExecuteNonQueryStoredProcedure(string sqlConnectionString, string storedProcedure)
        {
            return ExecuteNonQueryStoredProcedure(sqlConnectionString, storedProcedure, null);
        }

        public int ExecuteNonQueryStoredProcedure(string sqlConnectionString, string storedProcedure,
            List<SqlParameter> listOfSqlParameters)
        {
            var numberOfRowsAffected = 0;
            using (SqlConnection connection = new SqlConnection(sqlConnectionString))
            {
                using (SqlCommand command = new SqlCommand(storedProcedure))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Connection = connection;
                    if (listOfSqlParameters != null)
                    {
                        foreach (var sqlParameter in listOfSqlParameters)
                        {
                            command.Parameters.Add(sqlParameter);
                        }
                    }
                    connection.Open();
                    numberOfRowsAffected = command.ExecuteNonQuery();
                    connection.Close();
                }
            }
            return numberOfRowsAffected;
        }

        public List<T> ExecuteReaderStoredProcedure<T>(string sqlConnectionString, string storedProcedure)
        {
            return ExecuteReaderStoredProcedure<T>(sqlConnectionString, storedProcedure, null);
        }

        public List<T> ExecuteReaderStoredProcedure<T>(string sqlConnectionString, string storedProcedure,
            List<SqlParameter> listOfSqlParameters)
        {
            // TODO: Refactor this mess into something clean and readable
            var listOfObject = new List<object>();
            using (SqlConnection connection = new SqlConnection(sqlConnectionString))
            {
                using (SqlCommand command = new SqlCommand(storedProcedure))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Connection = connection;
                    if (listOfSqlParameters != null)
                    {
                        foreach (var sqlParameter in listOfSqlParameters)
                        {
                            command.Parameters.Add(sqlParameter);
                        }
                    }
                    connection.Open();
                    var sqlDataReader = command.ExecuteReader();
                    if (sqlDataReader.HasRows)
                    {
                        while (sqlDataReader.Read())
                        {
                            if (typeof(T).Equals(typeof(BlogPost)))
                            {
                                var blogPost = new BlogPost
                                {
                                    AuthorId = sqlDataReader.GetGuid(0),
                                    PostBody = sqlDataReader.GetString(1),
                                    PostId = sqlDataReader.GetGuid(2),
                                    PostTitle = sqlDataReader.GetString(3),
                                    TimeCreated = sqlDataReader.GetDateTime(4),
                                    TimeLastModified = sqlDataReader.GetDateTime(5)
                                };
                                listOfObject.Add(blogPost);
                            }
                            else if (typeof(T).Equals(typeof(BlogUser)))
                            {
                                var blogUser = new BlogUser
                                {
                                    Permissions = sqlDataReader.GetFieldValue<List<string>>(0),
                                    TimeRegistered = sqlDataReader.GetDateTime(1),
                                    UserId = sqlDataReader.GetGuid(2),
                                    UserName = sqlDataReader.GetString(3)
                                };
                                listOfObject.Add(blogUser);
                            }
                        }
                    }
                    sqlDataReader.Close();
                    connection.Close();
                }
            }
            return listOfObject as List<T>;
        }
    }
}