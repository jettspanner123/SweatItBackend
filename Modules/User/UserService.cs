using Microsoft.EntityFrameworkCore;
using SweatitBackEnd.Models.User;

namespace SweatitBackEnd.Modules.User;


public class UserService(AppDBContext context) : IUserService
{
    public Task<UserResponse> DeleteUserByIdAsync(string id)
    {
        throw new NotImplementedException();
    }

    public Task<bool> GetUserByIdAsync(string id)
    {
        throw new NotImplementedException();
    }

    public Task<bool> GetUserByUsernameAsync(string username)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> HealthCheck()
    {
        var _ = await context.Users.ToListAsync();
        return true;
    }

    public Task<UpdateUserServerResponse> PostUpdateUserByIdAsync(UpdateUserDTO userData)
    {
        throw new NotImplementedException();
    }
}