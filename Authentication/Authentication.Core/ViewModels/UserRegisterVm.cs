using System.ComponentModel.DataAnnotations;

namespace Authentication.Core.ViewModels;

public class UserRegisterVm
{
    [EmailAddress]
    public string Email { get; set; } = string.Empty;
    [Required]
    public string Password { get; set; } = string.Empty;
}
