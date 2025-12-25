
using SweatitBackEnd.Models.User;

public class RegisterServiceResponse(SafeUser? user, string message)
{
    public SafeUser? User = user;
    public string Message = message;
}