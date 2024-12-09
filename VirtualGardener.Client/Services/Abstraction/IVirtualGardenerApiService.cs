using VirtualGardener.Client.Models;
using VirtualGardener.Client.Utilities;
using IResult = VirtualGardener.Client.Utilities.IResult;

namespace VirtualGardener.Client.Services;

public interface IVirtualGardenerApiService
{
    Task<IResult> RegisterAsync(User user);
    Task<IResult<User>> LogInAsync(string email, string password);
}