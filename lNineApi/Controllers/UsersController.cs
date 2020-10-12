using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using lNineApi.Models;
using lnineapi.Services;

namespace lNineApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly LNineDBContext _context;
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }



        // GET: api/Users
        [HttpGet]
        public IEnumerable<NineUser> GetNineUsers()
        {
            //return await _context.NineUsers.ToListAsync();
            return  _userService.GetUsers();
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<NineUser>> GetNineUser(Guid id)
        {
            var nineUser = await _context.NineUsers.FindAsync(id);

            if (nineUser == null)
            {
                return NotFound();
            }

            return nineUser;
        }

        // PUT: api/Users/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public IActionResult PutNineUser(Guid id, NineUser nineUser)
        {
            if (id != nineUser.Id)
            {
                return BadRequest();
            }

            // _context.Entry(nineUser).State = EntityState.Modified;

            // try
            // {
            //     await _context.SaveChangesAsync();
            // }
            // catch (DbUpdateConcurrencyException)
            // {
            //     if (!NineUserExists(id))
            //     {
            //         return NotFound();
            //     }
            //     else
            //     {
            //         throw;
            //     }
            // }

            _userService.UpdateUser(nineUser);

            return NoContent();
        }


        // POST: api/Users
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public ActionResult<NineUser> PostNineUser(NineUser nineUser)
        {
            // nineUser.Id = Guid.NewGuid();
            // if (!NineUserExists(nineUser.Name))
            // {
            //     //var user = GetNineUser(nineUser.Id);

            // }
            // _context.NineUsers.Add(nineUser);
            // await _context.SaveChangesAsync();
            var usr = _userService.AddUser(nineUser);

            return CreatedAtAction("GetNineUser", new { id = nineUser.Id }, usr);
            //return CreatedAtAction("GetNineUsers",null);
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public  ActionResult<NineUser> DeleteNineUser(Guid id)
        {
           _userService.DeleteUser(id);

           return CreatedAtAction("GetNineUsers",null);
        }

        private bool NineUserExists(Guid id)
        {
            return _context.NineUsers.Any(e => e.Id == id);
        }

        private bool NineUserExists(string name)
        {
            return _context.NineUsers.Any(e => e.Name == name);
        }
    }
}
