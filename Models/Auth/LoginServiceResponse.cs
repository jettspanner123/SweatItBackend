using SweatitBackEnd.Models.User;

namespace SweatitBackEnd.Models.Auth;

public class LoginUserServiceResponse(SafeUser? user, string message, string token)
{
    public SafeUser? User { get; set; } = user;
    public string Message { get; set; } = message;
    public string Token { get; set; } = token;
}
