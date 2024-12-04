namespace VirtualGardenerServer.Infrastructure.Models;

public class User
{
    public Guid Id { get; set; }
    public string Username { get; init; }
    public string FirstName { get; init; }
    public string Surname { get; init; }
    public Role Role { get; init; }
}