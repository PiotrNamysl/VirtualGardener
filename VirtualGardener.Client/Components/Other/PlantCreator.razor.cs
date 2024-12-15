using Microsoft.AspNetCore.Components;
using VirtualGardener.Client.Models;
using VirtualGardener.Client.Services;
using VirtualGardener.Client.Services.Abstraction;

namespace VirtualGardener.Client.Components.Other;

public partial class PlantCreator : ComponentBase
{
    [Inject] private NavigationManager NavigationManager { get; set; }
    [Inject] private IVirtualGardenerLocalStorageService VirtualGardenerLocalStorageService { get; set; }
    [Parameter] public required UserAuthState UserAuthState { get; init; }


}