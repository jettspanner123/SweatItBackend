using Microsoft.EntityFrameworkCore;
using SweatitBackEnd.Models.Auth;
using SweatitBackEnd.Models.User;
using SweatitBackEnd.Utils;

namespace SweatitBackEnd.Modules.Auth;

public class AuthService(AppDBContext context, JwtService jwtService) : IAuthService {
    public async Task<bool> HealthCheck() {
        await context.Users.ToListAsync();
        return true;
    }

    public async Task<LoginUserServiceResponse> Login(LoginDTO userData) {
        var normalizedUsername = userData.Username.Trim().ToLower();
        var user = await context.Users
                       .Include(user => user.PersonCurrentData)
                       .Include(user => user.PersonFutureData)
                       .SingleOrDefaultAsync(user => user.Username.ToLower().Equals(normalizedUsername))
                   ?? throw new Exception("Username Not Found!");
        

        var isCorrectPassword = PasswordService.Verify(userData.Password, user.Password);

        if (!isCorrectPassword) throw new Exception("Wrong Password!");

        var token = jwtService.GenerateJwt(user);

        var responseUser = new SafeUser(
            id: user.Id,
            firstName: user.FirstName,
            lastName: user.LastName,
            username: user.Username,
            email: user.Email,
            personCurrentData: user.PersonCurrentData,
            personFutureData: user.PersonFutureData
        );
        return new LoginUserServiceResponse(responseUser, $"Welcome {responseUser.Username}", token);
    }

    public async Task<RegisterUserServiceResponse> Register(RegisterDTO userData) {
        var normalizedEmail = userData.Email.Trim().ToLower();
        var normalizedUsername = userData.Username.Trim().ToLower();

        var isConflicting = await context.Users
            .Where(user => user.Email.ToLower().Equals(normalizedEmail) ||
                           user.Username.ToLower().Equals(normalizedUsername))
            .Select(user => new { user.Email, user.Username })
            .FirstOrDefaultAsync();

        if (isConflicting is not null) {
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

        createdUser.PersonCurrentData = HelperFunctions.GetPersonDataFromDTO(userData.PersonCurrentData);
        createdUser.PersonFutureData = HelperFunctions.GetPersonDataFromDTO(userData.PersonFutureData);

        var token = jwtService.GenerateJwt(createdUser);

        var responseUser = new SafeUser(
            id: createdUser.Id,
            firstName: createdUser.FirstName,
            lastName: createdUser.LastName,
            username: createdUser.Username,
            email: createdUser.Email,
            personCurrentData: createdUser.PersonCurrentData,
            personFutureData: createdUser.PersonFutureData
        );

        context.Users.Add(createdUser);

        try {
            await context.SaveChangesAsync();
        }
        catch (DbUpdateException err) {
            throw new Exception($"Some Error Occured! Please try again later! {err.Message}");
        }

        return new RegisterUserServiceResponse(user: responseUser, token);
    }
}