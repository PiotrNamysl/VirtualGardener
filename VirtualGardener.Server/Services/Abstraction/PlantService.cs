using Microsoft.EntityFrameworkCore;
using VirtualGardener.Client.Models;
using VirtualGardenerServer.Database;
using VirtualGardenerServer.Utilities;
using IResult = VirtualGardenerServer.Utilities.IResult;

namespace VirtualGardenerServer.Services.Abstraction;

public class PlantService(DataContext dataContext) : IPlantService
{
    public async Task<IResult<List<Plant>>> GetPlantsAsync(Guid userId)
    {
        try
        {
            var plants = await dataContext.Plants.Where(p => p.User.Id == userId).Select(p => p).ToListAsync();

            if (plants.Any())
                return Result<List<Plant>>.Success(plants);

            return Result<List<Plant>>.Success(ResultStatusCode.NoDataFound);
        }
        catch (Exception e)
        {
            return Result<List<Plant>>.Error(ResultStatusCode.InternalServerError, e.Message);
        }
    }

    public async Task<IResult<Plant>> GetPlantDetailsAsync(Guid userId, Guid plantId)
    {
        try
        {
            var plant = await dataContext.Plants
                .Include(p => p.CareTasks)
                .FirstOrDefaultAsync(p => p.Id == plantId);

            if (plant is not null)
                return Result<Plant>.Success(plant);

            return Result<Plant>.Warning(ResultStatusCode.NoDataFound);
        }
        catch (Exception ex)
        {
            return Result<Plant>.Error(ResultStatusCode.InternalServerError);
        }
    }

    public async Task<IResult> AddPlantAsync(Guid userId, AddPlantRequest plant)
    {
        try
        {
            var user = await dataContext.Users.FirstOrDefaultAsync(u => u.Id == userId);
            if (user is not null)
            {
                var plantEntity = new Plant
                {
                    User = user,
                    Name = plant.Name,
                    Type = plant.Type,
                    PlantingDate = DateTime.UtcNow,
                    WateringFrequency = plant.WateringFrequency,
                    Location = plant.Location,
                    Notes = plant.Notes,
                    IsIndoor = plant.IsIndoor,
                };

                await dataContext.Plants.AddAsync(plantEntity);
                await dataContext.SaveChangesAsync();

                return Result<IResult>.Success(ResultStatusCode.Ok);
            }

            return Result<IResult>.Error(ResultStatusCode.NoDataFound);
        }
        catch (Exception ex)
        {
            return Result<IResult>.Error(ResultStatusCode.InternalServerError);
        }
    }
}