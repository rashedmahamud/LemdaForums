using LemdaForums.Data;
using LemdaForums.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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
            throw new NotImplementedException();
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
