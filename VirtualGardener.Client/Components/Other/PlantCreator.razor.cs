using Microsoft.AspNetCore.Components;
using VirtualGardener.Client.Models;
using VirtualGardener.Client.Models.Enums;
using VirtualGardener.Client.Services;
using VirtualGardener.Client.Services.Abstraction;

namespace VirtualGardener.Client.Components.Other;

public partial class PlantCreator : ComponentBase
{
    [Inject] private NavigationManager NavigationManager { get; set; }
    [Inject] private IVirtualGardenerLocalStorageService VirtualGardenerLocalStorageService { get; set; }
    [Inject] private IVirtualGardenerApiService VirtualGardenerApiService { get; set; }
    [Parameter] public required UserAuthState UserAuthState { get; set; }

    private bool _isPopupVisible = false;
    private Plant _plant = new();
    private string? _errorMessage;

    private async Task AddPlantAsync()
    {
        var result = await VirtualGardenerApiService.AddPlantAsync(UserAuthState.Id, _plant);
    }
}