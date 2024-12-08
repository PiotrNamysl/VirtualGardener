using Microsoft.AspNetCore.Components;
using VirtualGardener.Client.Services;

namespace VirtualGardener.Client.Components.Pages;

public partial class LoginPage
{
    [Inject] private IVirtualGardenerApiService _virtualGardenerApiService { get; set; }
    
}