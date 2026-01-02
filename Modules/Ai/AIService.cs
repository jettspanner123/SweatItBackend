using Microsoft.EntityFrameworkCore;
using SweatItBackEnd.Models.AI.Dto;
using SweatItBackEnd.Models.Diet;

namespace SweatItBackEnd.Modules.Ai;

public class AIService(AppDBContext context, GeminiService geminiService): IAIService {
    public async Task<bool> GetHealthCheck() {
        await context.Users.ToListAsync();
        return true;
    }
    
    public Task<List<FoodItem>> GetAIFoodItems() {
        return geminiService.GetAIFoodItems();
    }
}