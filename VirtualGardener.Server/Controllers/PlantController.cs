using Microsoft.AspNetCore.Mvc;
using VirtualGardener.Client.Models;
using VirtualGardenerServer.Services.Abstraction;
using VirtualGardenerServer.Utilities;
using IResult = VirtualGardenerServer.Utilities.IResult;

namespace VirtualGardenerServer.Controllers;

public class PlantController(IPlantService plantService) : BaseController
{
    [HttpGet("getPlants/{userId}")]
    public async Task<IResult<List<Plant>>> GetPlantsAsync(Guid userId) => await plantService.GetPlantsAsync(userId);

    [HttpGet("getPlantDetails/{id}")]
    public async Task<IResult<Plant>> GetPlantDetailsAsync(Guid userId, Guid plantId) => await plantService.GetPlantDetailsAsync(userId, plantId);

    [HttpPost("add/{userId}")]
    public async Task<IResult> AddPlantAsync(Guid userId, [FromBody] AddPlantRequest plant) => await plantService.AddPlantAsync(userId, plant);
}