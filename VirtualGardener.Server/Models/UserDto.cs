namespace VirtualGardenerServer.Models;

public class UserDto
{
    public required string Name { get; init; }
    public required string Email { get; init; }
    public required string Password { get; init; }
}