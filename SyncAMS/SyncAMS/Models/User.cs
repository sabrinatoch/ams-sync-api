using SyncAMS.DTOs;
using System;
using System.Collections.Generic;

namespace SyncAMS.Models;

public partial class User
{
    public int Iduser { get; set; }

    public string? LastName { get; set; }

    public string? FirstName { get; set; }

    public string Username { get; set; } = null!;

    public bool IsActive { get; set; }

    public bool ValidatedInAd { get; set; }

    public virtual EmployeeUser? EmployeeUser { get; set; }

    public virtual StudentUser? StudentUser { get; set; }

    public virtual ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();

    public User() { }
    public User(UserDTO dto) {
        Iduser = dto.Iduser;
        LastName = dto.LastName;
        FirstName = dto.FirstName;
        LastName = dto.LastName;
        IsActive = dto.IsActive;
        ValidatedInAd = dto.ValidatedInAd;
        EmployeeUser = null;
        StudentUser = null;
        UserRoles = new List<UserRole>();
    }
}
