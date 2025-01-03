using Microsoft.AspNetCore.Components;
using VirtualGardener.Client.Models;
using VirtualGardener.Client.Utilities;
using VirtualGardener.Shared.Models;

namespace VirtualGardener.Client.Components.Pages;

public partial class PlantDetails : BaseAuthorizedPage
{
    [Parameter] public string PlantId { get; set; }

    private Plant? _plant;

    private CareTask _careTaskToAdd = new()
    {
        TaskDate = DateTime.UtcNow,
    };

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        await base.OnAfterRenderAsync(firstRender);

        if (firstRender)
        {
            await InvokeAsync(StateHasChanged);
            var result = await VirtualGardenerApiService.GetPlantDetailsAsync(UserAuthState.Id, PlantId);

            if (result.IsFullSuccess())
                _plant = result.Data;

            else
                _plant = null;

            await InvokeAsync(StateHasChanged);
        }
    }

    private async Task AddCareTask()
    {
        var result = await VirtualGardenerApiService.AddCareTaskAsync(UserAuthState.Id, PlantId, _careTaskToAdd);

        if (result.IsFullSuccess())
        {
            await InvokeAsync(StateHasChanged);
            _careTaskToAdd = new CareTask();
        }
    }
}