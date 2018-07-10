using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using SSGeek.Web.Models;

namespace SSGeek.Web.DAL
{
    public class ForumPostSqlDAL 
    {
        /// <summary>
        /// Connection string to database.
        /// </summary>
        private string ConnectionString { get; } 

        public ForumPostSqlDAL (string connectionString)
        {
            this.ConnectionString = connectionString;
        }

        /// <summary>
        /// Gets all existing forum posts in the database.
        /// </summary>
        /// <returns></returns>
        public IList<ForumPostModel> GetAllPosts()
        {
            var posts = new List<ForumPostModel>();
            string sql = "Select * From forum_post;";
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        posts.Add(MapRowToPost(reader));
                    }
                }
            }
            catch (SqlException ex)
            {

                throw ex;
            }
            return posts;
        }

        /// <summary>
        /// Maps a Sql query's rows to an instance of a ForumPost object.
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        private ForumPostModel MapRowToPost(SqlDataReader reader)
        {
            return new ForumPostModel()
            {
                Username = Convert.ToString(reader["username"]),
                Subject = Convert.ToString(reader["subject"]),
                Message = Convert.ToString(reader["message"]),
                PostDate = Convert.ToDateTime(reader["post_date"])
            };
        }

        public bool SaveNewPost(ForumPostModel post)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();

                    string sql = "Insert Into forum_post Values (@name, @sub, @msg, GETDATE());";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@name", post.Username);
                    cmd.Parameters.AddWithValue("@sub", post.Subject);
                    cmd.Parameters.AddWithValue("@msg", post.Message);

                    if (cmd.ExecuteNonQuery()==1)
                    {
                        return true;
                    }
                }
            }
            catch (SqlException ex)
            {

                throw ex;
            }
            return false;
        }
    }
}
