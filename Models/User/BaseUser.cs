namespace SweatitBackEnd.Models.User;

public class BaseUser(string id, string firstName, string? lastName, string username, string email, string password)
{
    public string Id { get; set; } = id;
    public string FirstName { get; set; } = firstName;
    public string? LastName { get; set; } = lastName;
    public string Username { get; set; } = username;
    public string Email { get; set; } = email;
    public string Password { get; set; } = password;
    public DateTime CreateAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

}