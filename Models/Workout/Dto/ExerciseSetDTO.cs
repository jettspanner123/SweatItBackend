namespace SweatItBackEnd.Models.Workout.DTOs;

public class ExerciseSetDTO {
    public string ExerciseId { get; set; } = default!;
    public int MinReps { get; set; }
    public int MaxReps { get; set; }
    public double? Weight { get; set; }
    public bool IsWarmUp { get; set; }
}