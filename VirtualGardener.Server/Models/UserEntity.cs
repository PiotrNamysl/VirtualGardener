using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace VirtualGardenerServer.Models;

public class UserEntity
{
    [Key]
    public Guid Id { get; set; }

    public required string Name { get; set; }

    public required string Email { get; set; }

    public required string Password { get; set; }

    public required Role Role { get; set; }
}