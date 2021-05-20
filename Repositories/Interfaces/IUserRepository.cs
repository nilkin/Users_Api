using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Users_Api.Models;

namespace Users_Api.Repositories.Interfaces
{
   public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllAsync();
        Task<User> GetByIdAsync(Guid Id);
        Task<User> CreateAsync(User user);
        Task UpdateAsync(User user);
        Task Delete(Guid Id);
    }
}
