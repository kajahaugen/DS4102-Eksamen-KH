using System.ComponentModel.DataAnnotations;

namespace MilitaryApi.Models;

public class Vehicle
{
    [Key]
    public int Id { get; set; }
    public string? Name { get; set; }
    public bool LandVessel { get; set; }
    public bool AirVessel { get; set; }
    public bool WaterVessel { get; set; }
}