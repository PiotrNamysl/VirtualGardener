using VirtualGardenerServer.Models.Enums;

namespace VirtualGardener.Client.Models;

public class Plant
{
    public Guid Id { get; init; }
    public string Name { get; init; }
    public PlantType Type { get; init; }
    public DateTime PlantingDate { get; init; }
    public Frequency WateringFrequency { get; init; }
    public Frequency FertilizingFrequency => (Frequency)WateringFrequency + 1;
    public string Location { get; set; }
    public double Height { get; set; }
    public string Notes { get; set; }
    public bool IsIndoor { get; set; }

    public DateTime? LastWatering { get; set; }
    public DateTime? LastMeasuring { get; set; }
    public DateTime? LastFertilizing { get; set; }
    public DateTime? LastPruning { get; set; }
    public DateTime? LastPestControl { get; set; }
    public DateTime? LastRepotting { get; set; }

    public List<CareTask> CareTasks { get; set; }
}