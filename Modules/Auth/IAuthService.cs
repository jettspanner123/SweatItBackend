using SweatitBackEnd.Models.Auth;

namespace SweatitBackEnd.Modules.Auth;

public interface IAuthService
{

    Task<bool> HealthCheck();
    Task<RegisterServiceResponse> Register(RegisterDTO userData);
    Task<LoginServiceResponse> Login(LoginDTO userData);
}