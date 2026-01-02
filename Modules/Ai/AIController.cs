using Microsoft.AspNetCore.Mvc;
using SweatitBackEnd.Models.Base;

namespace SweatItBackEnd.Modules.Ai;

[Route("api/ai")]
[ApiController]
public class AIController(IAIService aiService, GeminiService geminiService): ControllerBase {

    [HttpGet("health")]
    public async Task<ActionResult<BaseResponse>> GetHealthCheck() {
        var _ = await aiService.GetHealthCheck();
        return Ok(new BaseResponse(true, "AI Service Working Fine!"));
    }

    [HttpGet("food")]
    public async Task<ActionResult<BaseResponse>> GetAIFoodItems() {
        return Ok(new {
            FoodItems = await geminiService.GetAIFoodItems(),
        });
    }
}