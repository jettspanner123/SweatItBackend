namespace SweatItBackEnd.Models.Diet;

public class FoodItem {
    public string Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    
    public string? Image { get; set; }
    
    public double Quantity { get; set; }
    public string QuantityUnit { get; set; }
    public double CaloriesPer100g { get; set; }
    public double ProteinPer100g { get; set; }
    public double CarbsPer100g { get; set; }
    public double FatsPer100g { get; set; }
    
    public RecommendationType Recommendation { get; set; }
    public DateTime ConsumptionTime { get; set; }
    public FoodType Type { get; set; }
}