using SweatitBackEnd.Models.User;

namespace SweatitBackEnd.Models.Auth;

public class AuthResponse(bool status, string message, SafeUser? user, List<string>? errors)
{
    public bool Status = status;
    public string Message = message;
    public SafeUser? user = user;
    public List<string>? errors = errors;
}