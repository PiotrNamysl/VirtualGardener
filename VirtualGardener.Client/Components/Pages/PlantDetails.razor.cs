using Microsoft.AspNetCore.Components;

namespace VirtualGardener.Client.Components.Pages;

public partial class PlantDetails : BaseAuthorizedPage
{

    [Parameter]
    public string PlantId { get; set; }
}