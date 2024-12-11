using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Options;
using Radzen;
using VirtualGardener.Client.Models;
using VirtualGardener.Client.Services;
using VirtualGardener.Client.Utilities;
using VirtualGardenerServer.Models.ServerSettings;

namespace VirtualGardener.Client.Components.Pages;

public partial class RegisterPage()
{
    [Inject] private IVirtualGardenerApiService _virtualGardenerApiService { get; init; }
    [Inject] private NavigationManager _navigationManager { get; init; }
    [Inject] private DialogService _dialogService { get; init; }

    private User _newUser = new();

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
    }

    private async Task Register()
    {
        var result = await _virtualGardenerApiService.RegisterAsync(_newUser);
        if (result.IsFullSuccess)
        {
            var answer = await _dialogService.Alert("You will be redirected to log in page.", "Registration Successful");
            _navigationManager.NavigateTo("/");
        }

        else
        {
            if (result.StatusCode == ResultStatusCode.DataAlreadyExist)
                await _dialogService.Alert("User already exists.", "Registration Failed");
            else
                await _dialogService.Alert("Please contact the administrator.", "Registration Failed");
        }
    }
}