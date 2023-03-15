using System.ComponentModel.DataAnnotations;

namespace MilitaryApi.Models;

public class Solider
{
    [Key]
    public int Id { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Image { get; set; }
    public string? Birthdate { get; set; }
    public string? Grade { get; set; }
    public string? Ranking { get; set; }
    public bool OutOnMission { get; set; }
    public string? MissionName {get; set; }
    
}