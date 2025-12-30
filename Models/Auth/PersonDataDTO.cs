using SweatitBackEnd.Models.User;

namespace SweatitBackEnd.Models.Auth;

public class PersonDataDTO {
    public required double Height { get; set; }
    public double Weight { get; set; }
    
    public required GenderEnum Gender { get; set; }
    public required LevelEnum Level { get; set; }
    public required BodyTypeEnum BodyType { get; set; }
    public required GoalEnum Goal { get; set; }
   
    public int DailyPoints { get; set; }
}