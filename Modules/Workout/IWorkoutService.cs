using SweatItBackEnd.Models.Workout.DTOs;
using WorkoutModel = SweatItBackEnd.Models.Workout;

namespace SweatItBackEnd.Modules.Workout;

public interface IWorkoutService {
    Task<bool> HealthCheck();
    Task<WorkoutModel.Workout> AddWorkoutForUserIdAsync(AddWorkoutDTO userId);
    Task<List<WorkoutModel.Workout>> GetAllWorkoutsAsync();
}