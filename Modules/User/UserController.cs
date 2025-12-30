using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using SweatitBackEnd.Models.Base;
using SweatitBackEnd.Models.User;

namespace SweatitBackEnd.Modules.User;

[Route("api/user")]
[ApiController]
public class UserController(IUserService userService) : ControllerBase {
    [HttpGet("health")]
    public async Task<ActionResult<BaseResponse>> GetHealthCheck() {
        var result = await userService.HealthCheck();
        return Ok(new BaseResponse(result, "User Service Working Fine!"));
    }

    [HttpGet("all")]
    public async Task<ActionResult<BaseResponse>> GetAllUsersAsync() {
        var result = await userService.GetAllUsersAsync();
        return Ok(new UsersResponse(true, "All Users!", result));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<UserResponse>> GetUserByIdAsync(string id) {
        try {
            var data = await userService.GetUserByIdAsync(id);
            return Ok(new UserResponse(true, "User Found!", data, null));
        }
        catch (Exception err) {
            return StatusCode(
                StatusCodes.Status500InternalServerError,
                new UserResponse(false, err.Message, null, [err.Message])
            );
        }
    }

    [HttpPost()]
    public async Task<ActionResult<UpdateUserResponse>> PostUpdateUserByIdAsync([FromBody] UpdateUserDTO userData) {
        try {
            var data = await userService.PostUpdateUserByIdAsync(userData);
            return Ok(new UpdateUserResponse(true, "User Updated Successfull!", data.PreviousUserData,
                data.CurrentUserData));
        }
        catch (Exception err) {
            return Ok(new UpdateUserResponse(true, err.Message, null, null));
        }
    }
}