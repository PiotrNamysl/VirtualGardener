using VirtualGardenerServer.Models;
using IResult = VirtualGardenerServer.Utilities.IResult;

namespace VirtualGardenerServer.Services.Abstraction;

public interface IAuthService
{
    public Task<IResult> RegisterAsync(UserDto userDto);
    public Task<IResult> SignInAsync(string email, string password);
}