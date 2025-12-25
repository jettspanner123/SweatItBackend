using SweatitBackEnd.Models.User;

namespace SweatitBackEnd.Modules.User;

public interface IUserService
{
    // Get
    Task<bool> HealthCheck();
    Task<bool> GetUserByIdAsync(string id);
    Task<bool> GetUserByUsernameAsync(string username);

    // Post
    Task<UpdateUserServerResponse> PostUpdateUserByIdAsync(UpdateUserDTO userData);
    
    // Put

    // Delete
    Task<UserResponse> DeleteUserByIdAsync(string id);

}