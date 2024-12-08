using VirtualGardener.Client.Models;
using IResult = VirtualGardener.Client.Utilities.IResult;

namespace VirtualGardener.Client.Services;

public interface IVirtualGardenerApiService
{
    Task<IResult> RegisterAsync(User user);
    Task<IResult> LogInAsync(string email, string password);
}