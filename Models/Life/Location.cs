namespace SweatItBackEnd.Models.Life;

public class Location {
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string Country { get; set; }
    public string State { get; set; }
    public string City { get; set; }
}