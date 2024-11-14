using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SyncAMS.DAL;
using SyncAMS.DTOs;
using SyncAMS.Models;

namespace SyncAMS.Controllers
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
        public async Task<ActionResult<IEnumerable<UserDTO>>> GetUsers()
        {
            return await _userRepo.GetAll();
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserDTO>> GetUser(int id)
        {
            var user = await _userRepo.GetById(id);

            if (user == null)
            {
                return NotFound();
            }
            var dto = new UserDTO(user);
            return dto;
        }

        // PUT: api/Users/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, UserDTO userDTO)
        {
            if (id != userDTO.Iduser)
            {
                return BadRequest();
            }

            try
            {
                await _userRepo.Update(userDTO);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!(await UserExists(id)))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Users
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(UserDTO userDTO)
        {
            await _userRepo.Add(userDTO);

            return CreatedAtAction("GetUser", new { id = userDTO.Iduser }, userDTO);
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _userRepo.GetById(id);
            if (user == null)
            {
                return NotFound();
            }

            await _userRepo.Delete(id);

            return NoContent();
        }

        private async Task<bool> UserExists(int id)
        {
            return await _userRepo.GetById(id) != null;
        }
    }
}
