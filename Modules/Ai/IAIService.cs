using SweatItBackEnd.Models.AI.Dto;
using SweatItBackEnd.Models.Diet;

namespace SweatItBackEnd.Modules.Ai;

public interface IAIService {
   Task<bool> GetHealthCheck();
   Task<List<FoodItem>> GetAIFoodItems();
}