using SyncAMS.Models;

namespace SyncAMS.DTOs {
    public class UserDTO {
        public int Iduser { get; set; }

        public string? LastName { get; set; }

        public string? FirstName { get; set; }

        public string Username { get; set; } = null!;

        public bool IsActive { get; set; }

        public bool ValidatedInAd { get; set; }

        public UserDTO() { }
        public UserDTO(User user) {
            Iduser = user.Iduser;
            FirstName = user.FirstName;
            LastName = user.LastName;
            IsActive = user.IsActive;
            ValidatedInAd = user.ValidatedInAd;
        }
    }
}
