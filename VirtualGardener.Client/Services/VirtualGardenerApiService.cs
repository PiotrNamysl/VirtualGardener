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

        try
        {
            var url = $"{_baseUrl}plant/getPlants/{userId}";
        
            var response = await client.GetAsync(url);
            var responseBody = await response.Content.ReadAsStringAsync();
            var parsedResponse = JsonConvert.DeserializeObject<Result<List<Plant>>>(responseBody);
        
            if (parsedResponse.IsFullSuccess())
                return parsedResponse;
        
            else if (parsedResponse.StatusCode == ResultStatusCode.DataAlreadyExist)
                return Result<List<Plant>>.Warning(ResultStatusCode.DataAlreadyExist);
        
            return Result<List<Plant>>.Warning(ResultStatusCode.UserCreationFailed);
        }
        catch (Exception ex)
        {
            return Result<List<Plant>>.Error(ResultStatusCode.Unknown);
        }
        
    }

    public async Task<IResult> AddPlantAsync(Guid userId, Plant plant)
    {
        using var client = new HttpClient();

        try
        {
            var url = $"{_baseUrl}plant/add/{userId}";

            var content = new StringContent(JsonConvert.SerializeObject(plant), Encoding.UTF8, "application/json");

            var response = await client.PostAsync(url, content);
            var responseBody = await response.Content.ReadAsStringAsync();
            var parsedResponse = JsonConvert.DeserializeObject<IResult>(responseBody);

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
}