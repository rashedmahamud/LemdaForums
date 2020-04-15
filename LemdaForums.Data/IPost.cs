using LemdaForums.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LemdaForums.Data
{
   public interface IPost
    {

        Post GetById(int id);
        IEnumerable<Post> GetAll();
        IEnumerable<Post> GetFilteredPost(string searchQuery);
        IEnumerable<Post> GetPostByForum(int id);

        Task Add(Post post);
        Task Delete(int id);
        Task  EditPostContent(int id, string newContent);

    }
}
