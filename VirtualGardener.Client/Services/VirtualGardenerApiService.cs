using System.Net;
using System.Text;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using VirtualGardener.Client.Models;
using VirtualGardener.Client.Utilities;
using VirtualGardenerServer.Models.ServerSettings;
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
}