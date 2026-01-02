using SweatitBackEnd.Models.Base;

namespace SweatItBackEnd.Models.Workout;

public class WorkoutResponse(bool status, string message): BaseResponse(status, message) {
    public Workout Workout { get; set; }
    public List<string>? Errors { get; set; }
}