using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using lNineApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace lnineapi.Services
{
    public interface IUserService
    {
         
        // NineUser GetNineUserByIdAsync(Guid Id);
        IEnumerable<NineUser> GetUsers();
        NineUser AddUser(NineUser nineUser);
        NineUser UpdateUser(NineUser nineUser);

        void DeleteUser(Guid id);
    }
}