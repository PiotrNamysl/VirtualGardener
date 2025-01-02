using Microsoft.AspNetCore.Components;
using VirtualGardener.Client.Models;
using VirtualGardener.Client.Services;
using VirtualGardener.Client.Services.Abstraction;

namespace VirtualGardener.Client.Components.Pages;

public class BaseAuthorizedPage : ComponentBase
{
    [Inject] protected NavigationManager NavigationManager { get; init; }
    [Inject] protected IVirtualGardenerLocalStorageService VirtualGardenerLocalStorageService { get; init; }
    [Inject] protected IVirtualGardenerApiService VirtualGardenerApiService { get; init; }
    protected UserAuthState UserAuthState { get; set; } = new();
    protected string UserName => UserAuthState.Name;
    protected bool IsAuthorized => UserName is not null;

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            var userAuthState = await VirtualGardenerLocalStorageService.GetUserAuthStateAsync();
            if (userAuthState is not null)
                UserAuthState = userAuthState;
            else
                NavigationManager.NavigateTo("/logIn");
            
            await InvokeAsync(StateHasChanged);
        }
    }
}