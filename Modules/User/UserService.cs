using Microsoft.EntityFrameworkCore;
using SweatitBackEnd.Models.User;
using SweatitBackEnd.Utils;

namespace SweatitBackEnd.Modules.User;

public class UserService(AppDBContext context) : IUserService {
    public Task<UserResponse> DeleteUserByIdAsync(string id) {
        throw new NotImplementedException();
    }

    public async Task<List<SafeUser>> GetAllUsersAsync() {
        var users = await context.Users
            .Include(user => user.PersonCurrentData)
            .Include(user => user.PersonFutureData)
            .ToListAsync();
        var safeUsers = users
            .Select(user => new SafeUser(id: user.Id, username: user.Username, email: user.Email,
                firstName: user.FirstName, lastName: user.LastName, personCurrentData: user.PersonCurrentData,
                personFutureData: user.PersonFutureData));
        return safeUsers.ToList();
    }

    public async Task<SafeUser> GetUserByIdAsync(string id) {
        var user = await context.Users.FindAsync(id) ?? throw new Exception("User Not Found!");
        return HelperFunctions.GetSafeUserFromBaseUser(user);
    }

    public async Task<SafeUser> GetUserByUsernameAsync(string username) {
        var user =
            await context.Users.FirstOrDefaultAsync(user => user.Username.ToLower().Equals(username.ToLower())) ??
            throw new Exception("User Not Found!");
        return HelperFunctions.GetSafeUserFromBaseUser(user);
    }

    public async Task<bool> HealthCheck() {
        var _ = await context.Users.ToListAsync();
        return true;
    }

    public Task<UpdateUserServerResponse> PostUpdateUserByIdAsync(UpdateUserDTO userData) {
        throw new NotImplementedException();
    }
}