namespace VirtualGardenerServer.Models;

public class UserDto
{
    public required Guid Id { get; init; }
    public required string Name { get; init; }
    public required string Email { get; init; }
    public required Role Role { get; init; }
}