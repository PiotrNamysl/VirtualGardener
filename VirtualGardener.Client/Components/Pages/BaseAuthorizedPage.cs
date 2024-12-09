using Microsoft.AspNetCore.Components;
using VirtualGardener.Client.Models;
using VirtualGardener.Client.Services;

namespace VirtualGardener.Client.Components.Pages;

public partial class BaseAuthorizedPage() : ComponentBase
{
    [Inject] protected NavigationManager NavigationManager { get; init; }
    [Inject] protected ILocalStorageService LocalStorageService { get; init; }
    protected UserAuthState UserAuthState { get; set; } = new();
    protected string UserName => UserAuthState.Name;
    protected bool IsAuthorized => UserAuthState.Name is not null;

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            var userAuthState = await LocalStorageService.GetUserAuthStateAsync();
            if (userAuthState is not null)
                UserAuthState = userAuthState;
            else
                NavigationManager.NavigateTo("/logIn");
            
            await InvokeAsync(StateHasChanged);
        }
    }
}