using System.Net;
using System.Text;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using VirtualGardener.Client.Models;
using VirtualGardener.Client.Models.Enums;
using VirtualGardener.Client.Models.ServerSettings;
using VirtualGardener.Client.Services.Abstraction;
using VirtualGardener.Client.Utilities;
using IResult = VirtualGardener.Client.Utilities.IResult;

namespace VirtualGardener.Client.Services;

public class VirtualGardenerApiService(IOptions<ServerSettings> serverSettings) : IVirtualGardenerApiService
{
    private readonly string _baseUrl = serverSettings.Value.BaseUrl;

    public async Task<IResult> RegisterAsync(User user)
    {
        using var client = new HttpClient();

        try
        {
            var url = $"{_baseUrl}auth/register";
            var content = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");

            var response = await client.PostAsync(url, content);
            var responseBody = await response.Content.ReadAsStringAsync();
            var parsedResponse = JsonConvert.DeserializeObject<Result>(responseBody);

            if (parsedResponse.IsFullSuccess())
                return parsedResponse;

            else if (parsedResponse.StatusCode == ResultStatusCode.DataAlreadyExist)
                return Result.Warning(ResultStatusCode.DataAlreadyExist);

            return Result.Warning(ResultStatusCode.UserCreationFailed);
        }
        catch (Exception ex)
        {
            return Result.Error(ResultStatusCode.Unknown);
        }

        return Result.Success();
    }

    public async Task<IResult<User>> LogInAsync(string email, string password)
    {
        using var client = new HttpClient();

        try
        {
            var url = $"{_baseUrl}auth/logIn";

            var content = new StringContent(JsonConvert.SerializeObject(
                new LoginRequest
                {
                    Email = email,
                    Password = password
                }
            ), Encoding.UTF8, "application/json");

            var response = await client.PostAsync(url, content);
            var responseBody = await response.Content.ReadAsStringAsync();
            var parsedResponse = JsonConvert.DeserializeObject<Result<User>>(responseBody);

            if (parsedResponse.IsFullSuccess())
                return parsedResponse;

            else if (parsedResponse.StatusCode == ResultStatusCode.DataAlreadyExist)
                return Result<User>.Warning(ResultStatusCode.DataAlreadyExist);

            return Result<User>.Warning(ResultStatusCode.UserCreationFailed);
        }
        catch (Exception ex)
        {
            return Result<User>.Error(ResultStatusCode.Unknown);
        }
    }

    public async Task<IResult<List<Plant>>> GetMyPlantsAsync(Guid userId)
    {
        using var client = new HttpClient();

        // try
        // {
        //     var url = $"{_baseUrl}plants/{userId}";
        //
        //     var response = await client.GetAsync(url);
        //     var responseBody = await response.Content.ReadAsStringAsync();
        //     var parsedResponse = JsonConvert.DeserializeObject<Result<Plant>>(responseBody);
        //
        //     if (parsedResponse.IsFullSuccess())
        //         return parsedResponse;
        //
        //     else if (parsedResponse.StatusCode == ResultStatusCode.DataAlreadyExist)
        //         return Result<Plant>.Warning(ResultStatusCode.DataAlreadyExist);
        //
        //     return Result<Plant>.Warning(ResultStatusCode.UserCreationFailed);
        // }
        // catch (Exception ex)
        // {
        //     return Result<Plant>.Error(ResultStatusCode.Unknown);
        // }

        return Result<List<Plant>>.Success([
            new Plant
            {
                Id = Guid.NewGuid(),
                Name = "Rose",
                Type = PlantType.Flower,
                PlantingDate = new DateTime(2023, 5, 10),
                Location = "Garden",
                Height = 50,
                Notes = "Thrives in sunlight, water twice a week.",
                IsIndoor = false,
                LastWatering = DateTime.Now.AddDays(-1),
                LastMeasuring = DateTime.Now.AddDays(-7),
                LastFertilizing = DateTime.Now.AddMonths(-1),
                LastPruning = DateTime.Now.AddMonths(-3),
                LastPestControl = DateTime.Now.AddMonths(-6),
                LastRepotting = null
            },
            new Plant
            {
                Id = Guid.NewGuid(),
                Name = "Ficus",
                Type = PlantType.Tree,
                PlantingDate = new DateTime(2021, 3, 15),
                Location = "Living Room",
                Height = 180, 
                Notes = "Needs occasional misting, avoid overwatering.",
                IsIndoor = true,
                LastWatering = DateTime.Now.AddDays(-3),
                LastMeasuring = DateTime.Now.AddMonths(-2),
                LastFertilizing = DateTime.Now.AddMonths(-5),
                LastPruning = null,
                LastPestControl = null,
                LastRepotting = DateTime.Now.AddMonths(-12)
            },
            new Plant
            {
                Id = Guid.NewGuid(),
                Name = "Basil",
                Type = PlantType.Herb,
                PlantingDate = new DateTime(2024, 6, 1),
                Location = "Kitchen",
                Height = 25, 
                Notes = "Harvest leaves regularly to encourage growth.",
                IsIndoor = true,
                LastWatering = DateTime.Now.AddDays(-2),
                LastMeasuring = null,
                LastFertilizing = DateTime.Now.AddMonths(-1),
                LastPruning = DateTime.Now.AddMonths(-2),
                LastPestControl = null,
                LastRepotting = null
            }
        ]);
    }
}