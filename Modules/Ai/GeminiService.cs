using System.Text.Json;
using System.Text.Json.Serialization;
using Google.GenAI;
using Google.GenAI.Types;
using SweatItBackEnd.Models.Diet;

namespace SweatItBackEnd.Modules.Ai;

public class GeminiService {
    private readonly Client _client;

    public GeminiService(IConfiguration config) {
        this._client = new Client(apiKey: config["Gemini:ApiKey"]);
    }

    public async Task<List<FoodItem>> GetAIFoodItems() {
        var generationConfiguration = new GenerateContentConfig {
            ResponseMimeType = "application/json",
            ResponseSchema = GeminiHelperService.FoodListSchema
        };

        var response = await this._client.Models.GenerateContentAsync(
            model: "gemini-2.5-flash",
            contents:
            "Generate me 3 means with 30g protein each. Each meal should be worth less than 150 rupees, everything should be native to indian people and India. By native I don't mean vegetarian.",
            config: generationConfiguration
        );

        var json = response.Candidates[0].Content.Parts[0].Text;
        var options = new JsonSerializerOptions {
            PropertyNameCaseInsensitive = true,
            Converters = { new JsonStringEnumConverter() }
        };

        List<FoodItem> foodItems = JsonSerializer.Deserialize<List<FoodItem>>(json, options) ?? new List<FoodItem>();
        return foodItems.Select(f => new FoodItem {
            Id = f.Id ?? Guid.NewGuid().ToString(),
            Name = f.Name,
            Description = f.Description,
            Image = f.Image,
            Quantity = f.Quantity,
            QuantityUnit = f.QuantityUnit,
            CaloriesPer100g = f.CaloriesPer100g,
            ProteinPer100g = f.ProteinPer100g,
            CarbsPer100g = f.CarbsPer100g,
            FatsPer100g = f.FatsPer100g,
            Recommendation = f.Recommendation,
            ConsumptionTime = f.ConsumptionTime == default
                ? DateTime.UtcNow
                : f.ConsumptionTime,
            Type = f.Type
        }).ToList();
    }
}