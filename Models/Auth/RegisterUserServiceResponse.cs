using SweatitBackEnd.Models.User;

namespace SweatitBackEnd.Models.Auth;

public class RegisterUserServiceResponse(SafeUser? user = null, string token = "") {
    public SafeUser? User { get; set; } = user;
    public string Token { get; set; } = token;
}