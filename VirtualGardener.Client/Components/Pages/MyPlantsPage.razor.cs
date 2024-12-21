using VirtualGardener.Client.Models;

namespace VirtualGardener.Client.Components.Pages;

public partial class MyPlantsPage : BaseAuthorizedPage
{
    private List<Plant> _myPlants = [];

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        await base.OnAfterRenderAsync(firstRender);
        if (firstRender)
        {
            var result = await VirtualGardenerApiService.GetMyPlantsAsync(UserAuthState.Id);
            if (result.IsFullSuccess())
            {
                _myPlants.AddRange(result.Data);
            }
            
            await InvokeAsync(StateHasChanged);
        }
    }
}