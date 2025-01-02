using Microsoft.AspNetCore.Components;
using VirtualGardener.Client.Models;

namespace VirtualGardener.Client.Components.Other;

public partial class PlantsList : ComponentBase
{
    [Parameter] public required List<Plant> PlantsSource { get; init; }
    [Inject] private NavigationManager NavigationManager { get; set; }

    private void GoToDetails(Plant plant)
    {
        NavigationManager.NavigateTo($"/PlantDetails/{plant.Id}");
    }

    private string FormatNullableDate(DateTime? date)
    {
        return date.HasValue ? date.Value.ToShortDateString() : "No data";
    }
}