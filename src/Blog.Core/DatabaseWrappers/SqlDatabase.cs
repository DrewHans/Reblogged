using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Blog.Core
{
    public class SqlDatabase : ISqlDatabase
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

        public List<BlogPost> ExecuteBlogPostReaderStoredProcedure(string sqlConnectionString, string storedProcedure)
        {
            return ExecuteBlogPostReaderStoredProcedure(sqlConnectionString, storedProcedure, null);
        }

        public List<BlogPost> ExecuteBlogPostReaderStoredProcedure(string sqlConnectionString, string storedProcedure,
            List<SqlParameter> listOfSqlParameters)
        {
            var listOfBlogPost = new List<BlogPost>();
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
                            var blogPost = new BlogPost
                            {
                                AuthorId = (Guid)sqlDataReader[0],
                                PostBody = (string)sqlDataReader[1],
                                PostId = (Guid)sqlDataReader[2],
                                PostTitle = (string)sqlDataReader[3],
                                TimeCreated = (DateTime)sqlDataReader[4],
                                TimeLastModified = (DateTime)sqlDataReader[5]
                            };
                            listOfBlogPost.Add(blogPost);
                        }
                    }
                    sqlDataReader.Close();
                    connection.Close();
                }
            }
            return listOfBlogPost;
        }

        public List<BlogUser> ExecuteBlogUserReaderStoredProcedure(string sqlConnectionString, string storedProcedure)
        {
            return ExecuteBlogUserReaderStoredProcedure(sqlConnectionString, storedProcedure, null);
        }

        public List<BlogUser> ExecuteBlogUserReaderStoredProcedure(string sqlConnectionString, string storedProcedure,
            List<SqlParameter> listOfSqlParameters)
        {
            var listOfBlogUser = new List<BlogUser>();
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
                            var blogUser = new BlogUser
                            {
                                Permissions = (List<string>)sqlDataReader[0],
                                TimeRegistered = (DateTime)sqlDataReader[1],
                                UserId = (Guid)sqlDataReader[2],
                                UserName = (string)sqlDataReader[3]
                            };
                            listOfBlogUser.Add(blogUser);
                        }
                    }
                    sqlDataReader.Close();
                    connection.Close();
                }
            }
            return listOfBlogUser;
        }
    }
}