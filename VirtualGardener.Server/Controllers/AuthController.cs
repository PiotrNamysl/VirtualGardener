using Microsoft.AspNetCore.Mvc;
using VirtualGardenerServer.Models;
using VirtualGardenerServer.Services.Abstraction;
using VirtualGardenerServer.Utilities;
using IResult = VirtualGardenerServer.Utilities.IResult;

namespace VirtualGardenerServer.Controllers;

public class AuthController(IAuthService authService) : BaseController
{
    [HttpPost("register")]
    public async Task<IResult> RegisterAsync(UserDto userDto)
    {
        var result = await authService.RegisterAsync(userDto);

        return result;
    }

    [HttpPost("signIn")]
    public async Task<IResult> SignInAsync(string email, string password)
    {
        var result = await authService.SignInAsync(email, password);

        return result;
    }
}