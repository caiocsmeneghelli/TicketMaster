using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketMaster.Domain.Entities;
using TicketMaster.Domain.Repositories;

namespace TicketMaster.Infrastructure.Persistence.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly TicketMasterDbContext _dbContext;
        public UserRepository(TicketMasterDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> CreateUserAsync(User user)
        {
            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();
            return user.Id;
        }

        public async Task<User?> FindByEmailAsync(string email)
        {
            return await _dbContext.Users.SingleOrDefaultAsync(reg => reg.Email.Equals(email));
        }

        public async Task<User?> FindByIdAsync(int id)
        {
            return await _dbContext.Users.SingleOrDefaultAsync(reg => reg.Id == id);
        }
    }
}
