using SweatItBackEnd.Models.Life;
using SweatItBackEnd.Models.Workout;

namespace SweatitBackEnd.Models.User;

public class SafeUser
{
    public string Id { get; set; }
    public string FirstName { get; set; }
    public string? LastName { get; set; }
    public string Username { get; set; }
    public string Email { get; set; } 
    
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; }
    
    public PersonData PersonCurrentData { get; set; }
    public PersonData PersonFutureData { get; set; }
    public List<Workout> Workouts { get; set; }
    
    public List<Allergy>? Allergies { get; set; }
    public Location? Location { get; set; }
}