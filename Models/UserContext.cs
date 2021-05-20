using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Users_Api.Models
{
    public class UserContext:DbContext
    {
        public UserContext(DbContextOptions<UserContext> opt)
            :base(opt)
        {
            Database.EnsureCreated();
        }
        public DbSet<User> Users { get; set; }
       
    }
}
