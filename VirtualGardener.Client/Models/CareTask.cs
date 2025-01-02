using System.ComponentModel.DataAnnotations;
using VirtualGardener.Client.Models.Enums;

namespace VirtualGardener.Client.Models;

public class CareTask
{
    public Guid Id { get; set; }
    public Guid PlantId { get; set; }
    public CareTaskType ActionType { get; set; }
    public string Description { get; set; }
    public DateTime TaskDate { get; set; }
    public string Notes { get; set; }
}