using LemdaForums.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LemdaForums.Data
{
    public interface IForum
    {
        Forum GetById(int id);
        IEnumerable<Forum> GetAll();
        IEnumerable<ApplicationUser> GetAllActiveUsers();

        Task Create(Forum forum);
        Task Delete(int id);
        Task UpdateForumTitle(int fouumId, string newTitile);

        Task UpdateForumDescription(int fouumId, string newDescription);



    }
}
