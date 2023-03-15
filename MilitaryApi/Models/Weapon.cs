using System.ComponentModel.DataAnnotations;

namespace MilitaryApi.Models;

public class Weapon
{
    [Key]
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Type { get; set; }
    public string? Image { get; set; }
    public int MagazinSize { get; set; }
}