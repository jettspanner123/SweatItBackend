namespace SweatItBackEnd.Models.Workout;

public class ExerciseSet {
    public string Id { get; set; } = Guid.NewGuid().ToString();

    public string WorkoutId { get; set; } = default!;
    public Workout Workout { get; set; } = default!;

    public string ExerciseId { get; set; } = default!;
    public Exercise Exercise { get; set; } = default!;
    
    public int MinReps { get; set; }
    public int MaxReps { get; set; }
    public double? Weight { get; set; }

    public bool IsWarmUp { get; set; } = false;
}