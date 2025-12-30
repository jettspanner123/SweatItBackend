using System.ComponentModel.DataAnnotations;

namespace SweatitBackEnd.Models.Auth;

public class RegisterDTO
{
    [Required(ErrorMessage = "First Name Not Provided!")]
    [MinLength(1, ErrorMessage = "First name should be atleast 1 character!")]
    public string FirstName { get; set; } = string.Empty;

    public string? LastName { get; set; } = null;

    [Required(ErrorMessage = "Username Not Provided!")]
    [MinLength(8, ErrorMessage = "Username should be atleast 8 characters!")]
    [RegularExpression(
        @"^[a-zA-Z0-9_]+$",
        ErrorMessage = "Username can contain only letter, numbers and underscores!"
    )]
    public string Username { get; set; } = string.Empty;

    [Required(ErrorMessage = "Email Not Provided!")]
    [EmailAddress(ErrorMessage = "Invalid Email Address!")]
    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessage = "Password Not Provided!")]
    [MinLength(8, ErrorMessage = "Password should be of 8 characters!")]
    public string Password { get; set; } = string.Empty;
    
    [Required(ErrorMessage = "Person Current Data Not Provided!")]
    public required PersonDataDTO PersonCurrentData { get; set; }
    public required PersonDataDTO PersonFutureData { get; set; }
}