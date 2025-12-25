using SweatitBackEnd.Models.User;

namespace SweatitBackEnd.Models.Auth;

public class LoginServiceResponse(SafeUser? user, string message)
{
    public SafeUser? User = user;
    public string Message = message;
}
