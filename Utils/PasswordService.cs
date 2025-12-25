using BCrypt.Net;

namespace SweatitBackEnd.Utils;

public static class PasswordService
{
    private const int SALT_ROUNDS = 10;

    public static string Hash(string password)
    {
        return BCrypt.Net.BCrypt.HashPassword(password, SALT_ROUNDS);
    }

    public static bool Verify(string password, string hashPassword)
    {
        return BCrypt.Net.BCrypt.Verify(password, hashPassword);
    }
}