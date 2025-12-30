namespace SweatitBackEnd.Models.User;

public class PersonData {
    public string Id { get; set; }
    public double Height { get; set; }
    public double Weight { get; set; }
    public GenderEnum Gender { get; set; }
    public LevelEnum Level { get; set; }
    public BodyTypeEnum BodyType { get; set; }
    public GoalEnum Goal { get; set; }
    public int DailyPoints { get; set; }
}