using VirtualGardener.Client.Models;

namespace VirtualGardener.Client.Services;

public class LocalStorageService(Blazored.LocalStorage.ILocalStorageService localStorageService) : ILocalStorageService
{
    private const string UserAuthStateKey = "UserAuthState";

    public async Task<UserAuthState> GetUserAuthStateAsync()
        => await localStorageService.GetItemAsync<UserAuthState>(UserAuthStateKey);

    public async Task SetUserAuthStateAsync(UserAuthState userAuthState)
        => await localStorageService.SetItemAsync(UserAuthStateKey, userAuthState);
}