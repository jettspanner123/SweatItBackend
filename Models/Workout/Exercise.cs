using SweatitBackEnd.Models.Base;

namespace SweatItBackEnd.Models.Workout;

public class Exercise {
    public string Id { get; set; } = Guid.NewGuid().ToString();
    
    public string Name { get; set; }
    public string? Description { get; set; }

    public List<Muscle> Muscles { get; set; } = new();
    public List<Equipment> Equipments { get; set; } = new();
    
    public ExerciseType Type { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;
}