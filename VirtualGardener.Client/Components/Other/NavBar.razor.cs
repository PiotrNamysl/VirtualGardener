using Microsoft.AspNetCore.Components;
using VirtualGardener.Client.Models;
using VirtualGardener.Client.Services;
using VirtualGardener.Client.Services.Abstraction;

namespace VirtualGardener.Client.Components.Other;

public partial class NavBar : ComponentBase
{
    [Inject] private NavigationManager NavigationManager { get; set; }
    [Inject] private IVirtualGardenerLocalStorageService VirtualGardenerLocalStorageService { get; set; }
    [Parameter] public required UserAuthState UserAuthState { get; init; }


    private bool _isAccountDetailsVisible = false;

    private async Task SignOutAsync()
    {
        await VirtualGardenerLocalStorageService.ClearUserAuthState();
        NavigationManager.NavigateTo("/logIn");
    }

    private async void ChangeAccountDetailsVisibility()
    {
        _isAccountDetailsVisible = !_isAccountDetailsVisible;
    }
}