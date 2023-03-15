#nullable disable
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MilitaryApi.Models;

namespace MilitaryApi.Controllers;

[ApiController]
[Route("[controller]")]

public class WeaponController : ControllerBase
{
    //SKAPER KONTEKTSKLASSE
    private readonly MilitaryContext _context;
    public WeaponController(MilitaryContext context) 
    {
        _context = context; //Kontekstklasse intiterers
    } 

    //METODE SOM HENTER ALLE VÅPEN
    [HttpGet]
    public async Task<ActionResult<List<Weapon>>> Get() 
    {
        List<Weapon> weapons = await _context.Weapon.ToListAsync();
        return weapons;
    }

    //METODE SOM HENTER VÅPEN BASERT PÅ ID, NAVN OG GRAD
    [HttpGet("{id}")]
    public async Task<ActionResult<Weapon>> Get(int id) 
    {
        Weapon Weapon = await _context.Weapon.FindAsync(id);
        return Weapon;
    }

    [HttpGet]
    [Route("[action]/{name}")]
    public async Task<ActionResult<List<Weapon>>> GetByName(string name) 
    {
        List<Weapon> weapons = await _context.Weapon.Where( _weapons => _weapons.Name == name ).ToListAsync();
        return weapons;
    }

    [HttpGet]
    [Route("[action]/{type}")]
    public async Task<ActionResult<List<Weapon>>> GetByType(string type) 
    {
        List<Weapon> weapons = await _context.Weapon.Where( _weapons => _weapons.Type == type ).ToListAsync();
        return weapons;
    }


    //METODE SOM KAN REDIGERE VÅPEN
    [HttpPut]
    public async Task<ActionResult<Weapon>> Put(Weapon editedWeapon) 
    {
        _context.Entry(editedWeapon).State = EntityState.Modified; 
        await _context.SaveChangesAsync();

        return editedWeapon;

    }

    //METODE SOM KAN LEGGE TIL VÅPEN
    [HttpPost] 
    public async Task<ActionResult<Weapon>> Post(Weapon newWeapon )
    {
        _context.Weapon.Add(newWeapon);
        await _context.SaveChangesAsync(); 

        return newWeapon; 
    }

    //METODE SOM KAN SLETTE VÅPEN
    [HttpDelete("{id}")] 
    public async Task<IActionResult> Delete(int id)
    {
        Weapon Weapon = await _context.Weapon.FindAsync( id );
        _context.Weapon.Remove(Weapon); 
        await _context.SaveChangesAsync();

        return NoContent(); //returnerer 
    }

}