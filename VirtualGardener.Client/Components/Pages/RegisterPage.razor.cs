using Microsoft.AspNetCore.Components;
using VirtualGardener.Client.Models;
using VirtualGardener.Client.Services;

namespace VirtualGardener.Client.Components.Pages;

public partial class RegisterPage
{
    [Inject] private IVirtualGardenerApiService _virtualGardenerApiService { get; set; }

    protected override void OnInitialized()
    {
        base.OnInitialized();
    }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {

        await InvokeAsync(StateHasChanged);
    }

    private async Task Register()
    {
        await _virtualGardenerApiService.RegisterAsync(new User
        {
            Email = "asas",
            Name = "asas",
            Password = "123"
        });
    }
}