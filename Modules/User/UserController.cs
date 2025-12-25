using Microsoft.AspNetCore.Mvc;
using SweatitBackEnd.Models.Base;

namespace SweatitBackEnd.Modules.User;

[Route("api/user")]
[ApiController]
public class UserController(IUserService userService): ControllerBase
{
    
    [HttpGet("health")]
    public async Task<ActionResult<BaseResponse>> GetHealthCheck()
    {
        var result = await userService.HealthCheck();
        return Ok(new BaseResponse(result, "User Service Working Fine!"));
    }
}