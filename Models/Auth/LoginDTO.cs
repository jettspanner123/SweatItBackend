using System.ComponentModel.DataAnnotations;

namespace SweatitBackEnd.Models.Auth;

public class LoginDTO
{
    [Required(ErrorMessage = "Username Not Provided!")]
    public string Username = string.Empty;

    [Required(ErrorMessage = "Password Not Provided!")]
    [MinLength(8, ErrorMessage = "Password should be of 8 characters!")]
    public string Password = string.Empty;
}