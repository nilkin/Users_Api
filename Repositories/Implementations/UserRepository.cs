using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Users_Api.Models;
using Users_Api.Repositories.Interfaces;

namespace Users_Api.Repositories.Implementations
{
    public class UserRepository : IUserRepository
    {
        private readonly UserContext _context;

        public UserRepository(UserContext context)
        {
            _context = context;
        }
        public async Task<User> CreateAsync(User user)
        {
            _context.Users.Add(user);
           await _context.SaveChangesAsync();
           return user;
        }

        public async Task Delete(Guid Id)
        {
            var userDel = await _context.Users.FindAsync(Id);
             _context.Users.Remove(userDel);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> GetByIdAsync(Guid Id)
        {
            return await _context.Users.FindAsync(Id);
        }

        public async Task UpdateAsync(User user)
        {
            _context.Entry(user).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
