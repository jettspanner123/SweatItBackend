namespace SweatitBackEnd.Models.User;

public class SafeUser(string id, string firstName, string? lastName, string username, string email, PersonData personCurrentData, PersonData personFutureData)
{
    public string Id { get; set; } = id;
    public string FirstName { get; set; } = firstName;
    public string? LastName { get; set; } = lastName;
    public string Username { get; set; } = username;
    public string Email { get; set; } = email;
    public PersonData PersonCurrentData { get; set; } = personCurrentData;
    public PersonData PersonFutureData { get; set; } = personFutureData;
}