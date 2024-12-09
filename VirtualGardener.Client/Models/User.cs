namespace VirtualGardener.Client.Models;

public class User
{
    public string Name { get; set; }
    public string Email { get; set; }
    public Role Role { get; set; }
    public string? Password { get; set; }
}