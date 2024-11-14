using Microsoft.EntityFrameworkCore;
using SyncAMS.DTOs;
using SyncAMS.Models;

namespace SyncAMS.DAL {
    public class UserRepository : IUserRepository {
        private readonly AmsContext _context;
        public UserRepository(AmsContext context) { 
            _context = context;
        }

        public async Task Add(UserDTO userDTO) {
            User user = new User(userDTO);
            await _context.Users.AddAsync(user);
            await Save();
        }

        public async Task Delete(int id) {
            var user = await _context.Users.FindAsync(id);
            _context.Users.Remove(user);
            await Save();
        }

        public async Task<List<UserDTO>> GetAll() {
            var users = _context.Users.OrderBy(u => u.Username).ToList();
            List<UserDTO> dtos = users.Select(user => new UserDTO(user)).ToList();
            return dtos;
        }

        public async Task<User> GetById(int id) {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Iduser == id);
            return user;
        }

        public async Task<UserDTO> GetByUsername(string username) {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Username == username);
            return new UserDTO(user);
        }

        public async Task Save() {
            await _context.SaveChangesAsync();
        }

        public async Task Update(UserDTO userDTO) {
            var userToUpdate = await _context.Users.FindAsync(userDTO.Iduser);
            userToUpdate.Username = userDTO.Username;
            userToUpdate.FirstName = userDTO.FirstName;
            userToUpdate.LastName = userDTO.LastName;
            _context.Users.Update(userToUpdate);
            await Save();
        }
    }
}
