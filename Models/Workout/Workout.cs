using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;
using SweatitBackEnd.Models.Base;
using SweatitBackEnd.Models.User;

namespace SweatItBackEnd.Models.Workout;

public class Workout {
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string Name { get; set; }
    public string? Description { get; set; }
    public WorkoutCategory Category { get; set; }
    public string? Image { get; set; }
    public DifficultyLevel Difficulty { get; set; }

    public List<ExerciseSet> Sets { get; set; } = new();

    public string UserId { get; set; } = default!;
    public BaseUser User { get; set; } = default!;

    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime LastPerformed { get; set; }
}