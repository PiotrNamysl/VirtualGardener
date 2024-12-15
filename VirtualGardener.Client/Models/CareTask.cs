using VirtualGardener.Client.Models.Enums;

namespace VirtualGardener.Client.Models;

public class CareTask
{
    public Guid Id { get; init; }
    public Guid PlantId { get; init; }
    public CareTaskType ActionType { get; init; }
    public string Description { get; init; }
    public DateTime TaskDate { get; init; }
    public string Notes { get; init; }
}