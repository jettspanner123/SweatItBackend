using SweatitBackEnd.Models.Base;

namespace SweatItBackEnd.Models.Workout.DTOs;

public class AddWorkoutDTO {
    public string UserId { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
    public WorkoutCategory Category { get; set; }
    public string? Image { get; set; }
    public DifficultyLevel Difficulty { get; set; }
    
    public List<ExerciseSetDTO> Sets { get; set; }
}