using LemdaForums.Data;
using LemdaForums.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LamdaForums.Service
{
    public class FournService : IForum

    {
        private readonly ApplicationDbContext _context;

        public FournService( ApplicationDbContext context)
        {
            _context = context;
        }

        public Task Create(Forum forum)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Forum> GetAll()
        {
            return _context.Forums
                           .Include( forum=>forum.Posts);
        }

        public IEnumerable<ApplicationUser> GetAllActiveUsers()
        {
            throw new NotImplementedException();
        }

        public Forum GetById(int id)
        {

            var forum = _context.Forums.Where(f => f.Id == id)
                  .Include(f => f.Posts).ThenInclude(p => p.User)
                  .Include(f => f.Posts).ThenInclude(r => r.Replies).ThenInclude(p => p.User).FirstOrDefault();

            return forum;

        }

        public Task UpdateForumDescription(int fouumId, string newDescription)
        {
            throw new NotImplementedException();
        }

        public Task UpdateForumTitle(int fouumId, string newTitile)
        {
            throw new NotImplementedException();
        }
    }
}
