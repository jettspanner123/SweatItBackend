using Microsoft.EntityFrameworkCore;
using SweatItBackEnd.Exceptions;
using SweatItBackEnd.Models.Workout;
using SweatItBackEnd.Models.Workout.DTOs;
using WorkoutModel = SweatItBackEnd.Models.Workout;

namespace SweatItBackEnd.Modules.Workout;

public class WorkoutService(AppDBContext context) : IWorkoutService {
    public async Task<bool> HealthCheck() {
        await context.Users.ToListAsync();
        return true;
    }

    public async Task<WorkoutModel.Workout> AddWorkoutForUserIdAsync(AddWorkoutDTO data) {
        var user = await context.Users.FindAsync(data.UserId);
        if (user is null) throw new UserNotFoundException("User Not Found!");

        if (user.Id != data.UserId) throw new IdMismatchException("User Id Doesn't Match!");

        var workout = new WorkoutModel.Workout {
            UserId = data.UserId,
            Name = data.Name,
            Description = data.Description,
            Category = data.Category,
            Difficulty = data.Difficulty,
            Image = data.Image,
        };

        workout.Sets = data.Sets.Select(s => new ExerciseSet {
            ExerciseId = s.ExerciseId,
            MinReps = s.MinReps,
            MaxReps = s.MaxReps,
            IsWarmUp = s.IsWarmUp,
            Workout = workout
        }).ToList();

        await context.Workouts.AddAsync(workout);
        return workout;
    }

    public async Task<List<WorkoutModel.Workout>> GetAllWorkoutsAsync() {
        return await context.Workouts.ToListAsync();
    }
}