using VirtualGardener.Shared.Models.Enums;

namespace VirtualGardener.Client.Models;

public class UserAuthState
{
    public Guid Id { get; init; }
    public string? Name { get; init; }
    public string? Email { get; init; }
    public Role Role { get; init; }
}