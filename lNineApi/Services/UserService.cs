using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using lNineApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace lnineapi.Services
{
    public class UserService : IUserService
    {
        private const string emailDomain = "@locusnine.com";
        private readonly LNineDBContext _context;
        public UserService(LNineDBContext context)
        {
            _context = context;
        }

        public NineUser AddUser(NineUser nineUser)
        {            
            int userCount = GetNineUserCountByName(nineUser.Name);

            if (userCount == 0)            
                nineUser.Email = $"{nineUser.Name}{emailDomain}";            
            else
                nineUser.Email = $"{nineUser.Name}{userCount + 1}{emailDomain}";

            nineUser.Id = Guid.NewGuid();
           
            _context.NineUsers.Add(nineUser);
            _context.SaveChangesAsync();

            return GetNineUserByIdAsync(nineUser.Id);
        }

        public NineUser GetNineUserByIdAsync(Guid Id)
        {
             var user =  _context.NineUsers.FindAsync(Id);
             return user.Result;

        }

        private int GetNineUserCountByName(string name)
        {
            var email = $"{name}{emailDomain}";
            var existingUserCount = _context.NineUsers.CountAsync(u => u.Name.ToLower() == name.ToLower());
            return existingUserCount.Result;
        }

        public IEnumerable<NineUser> GetUsers()
        {
            var nonDeleted = from u in _context.NineUsers where u.isDeleted == false select u;           
           return nonDeleted.ToList();
        }

        public NineUser UpdateUser(NineUser nineUser)
        {
            _context.Entry(nineUser).State = EntityState.Modified;
           

            try
            {
                _context.SaveChangesAsync();
                return GetNineUserByIdAsync(nineUser.Id);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (GetNineUserCountByName(nineUser.Name) == 0)
                {
                    return null;
                }
                else
                {
                    throw;
                }
            }
        }

        public  void DeleteUser(Guid id)
        {
            var nineUser =  GetNineUserByIdAsync(id);
            
            if (nineUser != null)
            {
                nineUser.isDeleted= true;
                _context.Entry(nineUser).State = EntityState.Modified;
                //_context.NineUsers.Remove(nineUser);
                _context.SaveChangesAsync();
            }
        }
    }
}