using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PersonInfo.Models;
using PersonInfo.Repositories;

namespace PersonInfo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _userRepo;

        public UsersController(IUserRepository userRepo)
        {
            _userRepo = userRepo;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult> GetUsers()
        {
            return Ok(await _userRepo.GetAll());
        }

        // GET: api/Users/5
        [HttpGet("{name}")]
        public async Task<ActionResult> GetUser(string name)
        {
            var user = await _userRepo.GetByName(name);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        // PUT: api/Users/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public ActionResult PutUser(int id, User user)
        {
            if (id != user.Id)
            {
                return BadRequest();
            }

            try
            {
                if (ModelState.IsValid)
                {
                    _userRepo.Update(user);
                    return Ok();
                }
            }
            catch (Exception ex)
            {
                return BadRequest();
            }

            return NoContent();
        }

        // POST: api/Users
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public ActionResult PostUser(User user)
        {
            if (ModelState.IsValid)
            {
                _userRepo.Insert(user);
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            _userRepo.Delete(id);
            return Ok();
        }

    }
}

