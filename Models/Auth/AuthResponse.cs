using SweatitBackEnd.Models.User;

namespace SweatitBackEnd.Models.Auth;

public class AuthResponse(bool status, string message, SafeUser? user, string? token, List<string>? errors)
{
    public bool Status { get; set; } = status;
    public string Message { get; set; } = message;
    public SafeUser? User { get; set; } = user;
    public string? Token { get; set; } = token;
    public List<string>? Errors { get; set; } = errors;
}