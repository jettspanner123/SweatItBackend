using SweatitBackEnd.Models.User;

namespace SweatitBackEnd.Modules.User;

public interface IUserService
{
    // Get
    Task<bool> HealthCheck();
    Task<SafeUser> GetUserByIdAsync(string id);
    Task<SafeUser> GetUserByUsernameAsync(string username);
    Task<List<SafeUser>> GetAllUsersAsync();

    // Post
    Task<UpdateUserServerResponse> PostUpdateUserByIdAsync(UpdateUserDTO userData);
    
    // Put

    // Delete
    Task<UserResponse> DeleteUserByIdAsync(string id);

}