using System.Text;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using VirtualGardener.Client.Models;
using VirtualGardener.Client.Utilities;
using IResult = VirtualGardener.Client.Utilities.IResult;

namespace VirtualGardener.Client.Services;

public class VirtualGardenerApiService : IVirtualGardenerApiService
{
    public async Task<IResult> RegisterAsync(User user)
    {
        using var client = new HttpClient();

        try
        {
            var url = "https://localhost/api";
            var content = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");

            var response = await client.PostAsync(url, content);
            var responseBody = await response.Content.ReadAsStringAsync();
        }
        catch (HttpRequestException e)
        {
        }

        return Result.Success();
    }

    public async Task<IResult> LogInAsync(string email, string password)
    {
        return Result.Success();
    }
}