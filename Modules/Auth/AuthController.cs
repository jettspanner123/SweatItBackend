using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using SweatitBackEnd.Models.Auth;
using SweatitBackEnd.Models.Base;

namespace SweatitBackEnd.Modules.Auth;

[Route("api/auth")]
[ApiController]
public class AuthController(IAuthService authService) : ControllerBase {
    [HttpGet("health")]
    public async Task<ActionResult<BaseResponse>> GetHealthCheck() {
        var result = await authService.HealthCheck();
        return Ok(new BaseResponse(result, "Auth Service Working Fine!"));
    }

    [HttpPost("register")]
    public async Task<ActionResult<AuthResponse>> PostRegisterUserAsync([FromBody] RegisterDTO registerDto) {
        try {
            var data = await authService.Register(registerDto);
            return Ok(
                new AuthResponse(status: true, message: "User Registered Successfully!", user: data.User,
                    token: data.Token, errors: null)
            );
        }
        catch (Exception err) {
            if (err.Message.Contains("Already")) {
                return StatusCode(StatusCodes.Status409Conflict,
                    new AuthResponse(status: false, message: "Conflicting Names!", user: null, token: null,
                        errors: [err.Message]));
            }
            else {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new AuthResponse(status: false, message: "Something Went Wrong!", user: null, token: null,
                        errors: [err.Message]));
            }
        }
    }

    [HttpPost("login")]
    public async Task<ActionResult<AuthResponse>> PostLoginUserAsync([FromBody] LoginDTO userData) {
        try {
            var data = await authService.Login(userData);
            return Ok(new AuthResponse(true, data.Message, data.User, data.Token, null));
        }
        catch (Exception err) {
            return Unauthorized(new AuthResponse(false, "Unauthorized!", null, null, [err.Message]));
        }
    }
}