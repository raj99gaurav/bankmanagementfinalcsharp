using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BankManagementSystem.Models;
using BankManagementSystem.Service;

namespace BankManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _Service;
   


        public UsersController(IUserService Service)
        {
            _Service = Service;
          
        }

        //// GET: api/Users
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        //{
        //    return await _context.Users.ToListAsync();
        //}

        // GET: api/Users/5
        [HttpGet("{id}")]
        public IActionResult GetUser(string id)
        {
            var user = _Service.GetUser(id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        //// PUT: api/Users/5
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public IActionResult PutUser(string id,[FromBody] User user)
        {
            if (id != user.UserId)
            {
                return BadRequest();
            }
            else
            {
                _Service.UpdateUser(id,user);
                return Ok("User Updated");
            }
        }

        // POST: api/Users
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754

        [HttpPost("Signin")]
        public IActionResult SignIn([FromBody] UserLogin credential)
        {
            string username = credential.UserName;
            string password = credential.Password;
            if (username == null || password == null)
                return BadRequest("Invalid Username or Password");
            else
            {
                User user = _Service.AuthenticateMember(username, password);
                return Ok(user);
            }
        }

        [HttpPost("Signup")]
        public IActionResult SignUp([FromBody] User user)
        {
            if (user == null)
            {
                return BadRequest("Please Provide Data");
            }
            else
            {
                _Service.AddUser(user);
                return Ok("User Added");
            }

        }

       /* [HttpPost("Applyloan")]
        public IActionResult ApplyLoan([FromBody] UserLoan userloan)
        {
            if(userloan==null)
            {
                return BadRequest("Please Provide Data");
            }
            else
            {
                _Service.Loan(userloan);
                return Ok("User Added");
            }
        }*/

        //// DELETE: api/Users/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteUser(string id)
        //{
        //    var user = await _context.Users.FindAsync(id);
        //    if (user == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Users.Remove(user);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        //private bool UserExists(string id)
        //{
        //    return _context.Users.Any(e => e.UserId == id);
        //}
    }
}
