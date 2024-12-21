using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using VirtualGardener.Client.Models;

namespace VirtualGardenerServer.Models;

public class UserEntity
{
    [Key]
    public Guid Id { get; set; }

    public required string Name { get; set; }

    public required string Email { get; set; }

    public required string Password { get; set; }

    public required Role Role { get; set; }
    
    public ICollection<Plant> Plants { get; set; }
}