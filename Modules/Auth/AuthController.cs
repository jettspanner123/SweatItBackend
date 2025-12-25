using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using SweatitBackEnd.Models.Auth;
using SweatitBackEnd.Models.Base;

namespace SweatitBackEnd.Modules.Auth;

[Route("api/auth")]
[ApiController]
public class AuthController(IAuthService authService) : ControllerBase
{

    public override ActionResult ValidationProblem(ModelStateDictionary modelStateDictionary)
    {
        var errors = modelStateDictionary.Values
            .SelectMany(v => v.Errors)
            .Select(e => e.ErrorMessage)
            .ToList();

        return BadRequest(new AuthResponse(
            false,
            "Invalid Request Payload!",
            null,
            errors
        ));
    }

    [HttpGet("health")]
    public async Task<ActionResult<BaseResponse>> GetHealthCheck()
    {
        var result = await authService.HealthCheck();
        return Ok(new BaseResponse(result, "Auth Service Working Fine!"));
    }

    [HttpPost("register")]
    public async Task<ActionResult<AuthResponse>> PostRegisterUserAsync([FromBody] RegisterDTO registerDTO)
    {
        try
        {
            var data = await authService.Register(registerDTO);
            return Ok(
                new AuthResponse(true, data.Message, data.User, null)
            );
        }
        catch (Exception err)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new AuthResponse(false, "Please Try Again Later!", null, [err.Message]));
        }
    }

    [HttpPost("login")]
    public async Task<ActionResult<AuthResponse>> PostLoginUserAsync([FromBody] LoginDTO userData)
    {
        try
        {
            var data = await authService.Login(userData);
            return Ok(new AuthResponse(true, data.Message, data.User, null));
        }
        catch (Exception err)
        {
            return Unauthorized(new AuthResponse(false, "Unauthorized!", null, [err.Message]));
        }
    }
}