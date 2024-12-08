using System.Security.Cryptography;
using Microsoft.EntityFrameworkCore;
using System.Text;
using VirtualGardenerServer.Database;
using VirtualGardenerServer.Models;
using VirtualGardenerServer.Services.Abstraction;
using VirtualGardenerServer.Utilities;
using IResult = VirtualGardenerServer.Utilities.IResult;

namespace VirtualGardenerServer.Services;

public class AuthService(DataContext dataContext) : IAuthService
{
    public async Task<IResult> RegisterAsync(UserDto userDto)
    {
        try
        {
            var tryToGetUser = await dataContext.Users.FirstOrDefaultAsync(u => u.Email == userDto.Email);

            if (tryToGetUser is not null)
                return Result.Success(ResultStatusCode.DataAlreadyExist);

            var user = await dataContext.Users.AddAsync(new User
            {
                Email = userDto.Email,
                Name = userDto.Name,
                Password = GetHashedPassword(userDto.Password),
                Role = Role.User
            });

            await dataContext.SaveChangesAsync();

            return Result.Success(ResultStatusCode.Ok);
        }
        catch (Exception ex)
        {
            return Result.Error(ResultStatusCode.DatabaseError, ex.Message);
        }
    }

    public async Task<IResult> SignInAsync(string email, string password)
    {
        var user = await dataContext.Users.FirstOrDefaultAsync(u => u.Email == email);

        if (user is not null)
            return user.Password == GetHashedPassword(password)
                ? Result.Success()
                : Result.Warning(ResultStatusCode.AccessForbidden);

        return Result.Success(ResultStatusCode.NoDataFound);
    }

    private static string GetHashedPassword(string password)
        => Convert.ToHexString(SHA512.HashData(Encoding.UTF8.GetBytes(password))).ToLower();
}