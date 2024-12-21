using VirtualGardener.Client.Models;
using VirtualGardener.Client.Utilities;
using IResult = VirtualGardener.Client.Utilities.IResult;

namespace VirtualGardener.Client.Services.Abstraction;

public interface IVirtualGardenerApiService
{
    Task<IResult> RegisterAsync(User user);
    Task<IResult<User>> LogInAsync(string email, string password);
    Task<IResult<List<Plant>>> GetMyPlantsAsync(Guid userId);
    Task<IResult> AddPlantAsync(Guid userId, Plant plant);
    // Task<IResult<Plant>> GetMyPlantHistory(Guid userId);
}