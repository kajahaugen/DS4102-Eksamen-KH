#nullable disable
using Microsoft.EntityFrameworkCore;

namespace MilitaryApi.Models;

public class MilitaryContext : DbContext
{
    public MilitaryContext (DbContextOptions<MilitaryContext> options):base(options){}

    public DbSet<MilitaryApi.Models.Solider> Solider {get; set; }
    public DbSet<MilitaryApi.Models.Mission> Mission {get; set; }
    public DbSet<MilitaryApi.Models.Vehicle> Vehicle {get; set; }
    public DbSet<MilitaryApi.Models.Weapon> Weapon {get; set; }
}