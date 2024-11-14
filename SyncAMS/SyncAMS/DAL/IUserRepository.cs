using SyncAMS.DTOs;
using SyncAMS.Models;

namespace SyncAMS.DAL {
    public interface IUserRepository {
        Task<List<UserDTO>> GetAll();
        Task<User> GetById(int id);
        Task<UserDTO> GetByUsername(string username);
        Task Add(UserDTO userDTO);
        Task Update(UserDTO userDTO);
        Task Delete(int id);
        Task Save();
    }
}
