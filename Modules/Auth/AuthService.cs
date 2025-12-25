using Microsoft.EntityFrameworkCore;
using SweatitBackEnd.Models.Auth;
using SweatitBackEnd.Models.User;
using SweatitBackEnd.Utils;

namespace SweatitBackEnd.Modules.Auth;


public class AuthService(AppDBContext context) : IAuthService
{
    public async Task<bool> HealthCheck()
    {
        var _ = await context.Users.ToListAsync();
        return true;
    }

    public async Task<LoginServiceResponse> Login(LoginDTO userData)
    {
        var normalizedUsername = userData.Username.Trim().ToLower();
        var user = await context.Users
            .SingleOrDefaultAsync(user => user.Username.ToLower().Equals(normalizedUsername))
            ?? throw new Exception("Username Not Found!");

        var isCorrectPassword = PasswordService.Verify(user.Password, userData.Password);

        if (!isCorrectPassword) throw new Exception("Wrong Password!");

        var responseUser = new SafeUser(
            id: user.Id,
            firstName: user.FirstName,
            lastName: user.LastName,
            username: user.Username,
            email: user.Email
        );
        return new LoginServiceResponse(responseUser, $"Welcome {responseUser.Username}");
    }

    public async Task<RegisterServiceResponse> Register(RegisterDTO userData)
    {
        var normalizedEmail = userData.Email.Trim().ToLower();
        var normalizedUsername = userData.Username.Trim().ToLower();

        var isConflicting = await context.Users
            .Where(user => user.Email.ToLower().Equals(normalizedEmail) || user.Username.ToLower().Equals(normalizedUsername))
            .Select(user => new { user.Email, user.Username })
            .FirstOrDefaultAsync();

        if (isConflicting is not null)
        {
            if (isConflicting.Email == normalizedEmail) throw new Exception("Email Already Exists!");
            if (isConflicting.Username == normalizedUsername) throw new Exception("Username Already Exists!");
        }

        var hashedPassword = PasswordService.Hash(userData.Password);

        var createdUser = new BaseUser(
            id: Guid.NewGuid().ToString(),
            firstName: userData.FirstName,
            lastName: userData.LastName,
            username: normalizedUsername,
            email: normalizedEmail,
            password: hashedPassword
        );
        var responseUser = new SafeUser(
            id: createdUser.Id,
            firstName: createdUser.FirstName,
            lastName: createdUser.LastName,
            username: createdUser.Username,
            email: createdUser.Email
        );

        context.Users.Add(createdUser);

        try
        {
            await context.SaveChangesAsync();
        }
        catch (DbUpdateException err)
        {
            throw new Exception($"Some Error Occured! Please try again later! {err.Message}");
        }
        return new RegisterServiceResponse(responseUser, "User Creation Successful!");
    }
}