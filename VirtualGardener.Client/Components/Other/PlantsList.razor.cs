using Microsoft.AspNetCore.Components;
using VirtualGardener.Client.Models;

namespace VirtualGardener.Client.Components.Other;

public partial class PlantsList : ComponentBase
{
    [Parameter] public required List<Plant> PlantsSource { get; init; }
    
    private string FormatNullableDate(DateTime? date)
    {
        return date.HasValue ? date.Value.ToShortDateString() : "Brak danych";
    }
}