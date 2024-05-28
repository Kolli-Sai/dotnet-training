using Authentication.Core.Enums;
using System.ComponentModel.DataAnnotations;

namespace Authentication.Core.Entities;

public class User
{
    public Guid Id { get; set; }

    [EmailAddress]
    public string Email { get; set; } = string.Empty;
    public byte[] PasswordHash { get; set; } = null!;
    public byte[] PasswordSalt { get; set; } = null!;
    public UserRole  Role { get; set; }
}
