using System.ComponentModel.DataAnnotations;

namespace MilitaryApi.Models;

public class Mission
{
    [Key]
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
}