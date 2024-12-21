using System.ComponentModel.DataAnnotations.Schema;
using VirtualGardenerServer.Models;
using VirtualGardenerServer.Models.Enums;

namespace VirtualGardener.Client.Models;

public class AddPlantRequest
{
    public Guid Id { get; init; }
    public string Name { get; init; }
    public PlantType Type { get; init; }
    public DateTime PlantingDate { get; init; }
    public Frequency WateringFrequency { get; init; }
    public Frequency FertilizingFrequency => (Frequency)WateringFrequency + 1;
    public string Location { get; set; }
    public string? Notes { get; set; }
    public bool IsIndoor { get; set; }
}