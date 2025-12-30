using SweatitBackEnd.Models.Auth;
using SweatitBackEnd.Models.User;

namespace SweatitBackEnd.Modules.Auth;

public interface IAuthService
{
    Task<bool> HealthCheck();
    Task<RegisterUserServiceResponse> Register(RegisterDTO userData);
    Task<LoginUserServiceResponse> Login(LoginDTO userData);
}