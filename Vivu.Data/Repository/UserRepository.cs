using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vivu.Data.Base;
using Vivu.Data.Models;

namespace Vivu.Data.Repository
{
    public class UserRepository : GenericRepository<User>
    {
        public UserRepository() { }

        public UserRepository(VivuDiaryContext context) : base(context) { }

        public async Task<User> GetUserByUserName(string userName)
        {
            return await _context.Set<User>().FirstOrDefaultAsync(u => u.UserName == userName);
        }

        public async Task<User> GetUserByEmail(string email)
        {
            return await _context.Set<User>().FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<User> GetUserByPhoneNumber(string phoneNumber)
        {
            return await _context.Set<User>().FirstOrDefaultAsync(u => u.PhoneNumber == phoneNumber);
        }

    }
}
