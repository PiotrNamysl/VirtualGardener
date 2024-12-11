using Microsoft.AspNetCore.Components;
using VirtualGardener.Client.Models;
using VirtualGardener.Client.Services;

namespace VirtualGardener.Client.Components.Pages;

public partial class LoginPage
{
    [Inject] private IVirtualGardenerApiService _virtualGardenerApiService { get; set; }
    [Inject] private IVirtualGardenerLocalStorageService VirtualGardenerLocalStorageService { get; set; }
    [Inject] private NavigationManager _navigationManager { get; set; }

    private string _email = string.Empty;
    private string _password = string.Empty;
    private string _errorMessage = string.Empty;

    private async Task LoginAsync()
    {
        if (!(string.IsNullOrWhiteSpace(_email) || string.IsNullOrWhiteSpace(_password)))
        {
            var result = await _virtualGardenerApiService.LogInAsync(_email, _password);
            if (result.IsFullSuccess())
            {
                var user = result.Data;

                await VirtualGardenerLocalStorageService.SetUserAuthStateAsync(new UserAuthState
                {
                    Email = user.Email,
                    Name = user.Name,
                    Role = user.Role
                });

                _navigationManager.NavigateTo("/");
            }
        }
        
        _errorMessage = "Login failed!";
    }
}