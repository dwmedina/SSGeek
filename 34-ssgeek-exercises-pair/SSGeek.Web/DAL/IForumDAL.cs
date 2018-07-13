using SSGeek.Web.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace SSGeek.Web.DAL
{
   public interface IForumDAL
    {
        IList<ForumPostModel> GetAllPosts();
        ForumPostModel MapRowToPost(SqlDataReader reader);
        bool SaveNewPost(ForumPostModel post);
    }
}
