using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using SweatItBackEnd.Exceptions;
using SweatitBackEnd.Models.Base;
using SweatItBackEnd.Models.Workout;
using SweatItBackEnd.Models.Workout.DTOs;

namespace SweatItBackEnd.Modules.Workout;

[Route("api/workout")]
[ApiController]
public class WorkoutController(IWorkoutService workoutService) : ControllerBase {
    [HttpGet("health")]
    public async Task<ActionResult<BaseResponse>> GetHealthCheck() {
        var _ = await workoutService.HealthCheck();
        return Ok(new BaseResponse(status: true, message: "Workout Service Working Fine!"));
    }

    [HttpGet("all")]
    public async Task<ActionResult<BaseResponse>> GetAllWorkoutsAsync() {
        var workouts = await workoutService.GetAllWorkoutsAsync();
        return Ok(workouts);
    }

    [HttpPost("add")]
    public async Task<ActionResult<WorkoutResponse>> AddWorkoutForUserIdAsync([FromBody] AddWorkoutDTO addWorkoutData) {
        try {
            var workout = await workoutService.AddWorkoutForUserIdAsync(addWorkoutData);
            return Ok(new {
                Success = true,
                workout
            });
        }
        catch (UserNotFoundException err) {
            return NotFound(new BaseResponse(false, "User Not Found!"));
        }
        catch (IdMismatchException err) {
            return NotFound(new BaseResponse(false, "User Id Doesn't Match!"));
        }
        catch (Exception err) {
            return StatusCode(StatusCodes.Status500InternalServerError, err);
        }
    }
}