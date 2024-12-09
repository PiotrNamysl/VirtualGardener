using VirtualGardener.Client.Models;

namespace VirtualGardener.Client.Services;

public interface ILocalStorageService
{
    Task<UserAuthState> GetUserAuthStateAsync();
    Task SetUserAuthStateAsync(UserAuthState userAuthState);
}