using Google.GenAI.Types;
using Type = Google.GenAI.Types.Type;

namespace SweatItBackEnd.Modules.Ai;

public class GeminiHelperService {
    public static Schema FoodListSchema = new Schema {
        Type = Type.ARRAY,
        Items = new Schema {
            Type = Type.OBJECT,
            Properties = new Dictionary<string, Schema> {
                ["Name"] = new Schema { Type = Type.STRING },
                ["Description"] = new Schema { Type = Type.STRING },
                ["Image"] = new Schema { Type = Type.STRING, Nullable = true },
                ["Quantity"] = new Schema { Type = Type.NUMBER },
                ["QuantityUnit"] = new Schema { Type = Type.STRING },
                ["CaloriesPer100g"] = new Schema { Type = Type.NUMBER },
                ["ProteinPer100g"] = new Schema { Type = Type.NUMBER },
                ["CarbsPer100g"] = new Schema { Type = Type.NUMBER },
                ["FatsPer100g"] = new Schema { Type = Type.NUMBER },
                ["Recommendation"] = new Schema {
                    Type = Type.STRING,
                    Enum = new List<string> { "LessRecommended", "MoreRecommended", "NoRecommendation" }
                },
                ["Type"] = new Schema {
                    Type = Type.STRING,
                    Enum = new List<string> { "Whole", "Clean", "Processed", "Junk", "Beverage" }
                }
            },
            Required = new List<string> { "Name", "Quantity", "Recommendation", "Type" }
        }
    };
}