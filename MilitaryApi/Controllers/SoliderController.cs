#nullable disable
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MilitaryApi.Models;

namespace MilitaryApi.Controllers;

[ApiController]
[Route("[controller]")]

public class SoliderController : ControllerBase
{
    //SKAPER KONTEKTSKLASSE
    private readonly MilitaryContext _context;
    public SoliderController(MilitaryContext context) 
    {
        _context = context; //Kontekstklasse intiterers
    } 

    //METODE SOM HENTER ALLE SOLDATER
    [HttpGet]
    public async Task<ActionResult<List<Solider>>> Get() 
    {
        List<Solider> soliders = await _context.Solider.ToListAsync();
        return soliders;
    }

    //METODE SOM HENTER SOLDAT BASERT PÅ ID, NAVN OG GRAD
    [HttpGet("{id}")]
    public async Task<ActionResult<Solider>> Get(int id) 
    {
        Solider solider = await _context.Solider.FindAsync(id);
        return solider;
    }

    [HttpGet]
    [Route("[action]/{firstName}")]
    public async Task<ActionResult<List<Solider>>> GetByFirstName(string firstName) 
    {
        List<Solider> soliders = await _context.Solider.Where( _soliders => _soliders.FirstName == firstName ).ToListAsync();
        return soliders;
    }

    [HttpGet]
    [Route("[action]/{grade}")]
    public async Task<ActionResult<List<Solider>>> GetByGrade(string grade) 
    {
        List<Solider> soliders = await _context.Solider.Where( _soliders => _soliders.Grade == grade ).ToListAsync();
        return soliders;
    }


    //METODE SOM KAN REDIGERE SOLDAT
    [HttpPut]
    public async Task<ActionResult<Solider>> Put(Solider editedSolider) 
    {
        _context.Entry(editedSolider).State = EntityState.Modified; 
        await _context.SaveChangesAsync();

        return editedSolider;

    }

    //METODE SOM KAN LEGGE TIL SOLDAT
    [HttpPost] 
    public async Task<ActionResult<Solider>> Post(Solider newSolider )
    {
        _context.Solider.Add(newSolider); //Legger til
        await _context.SaveChangesAsync(); //Oppdaterer/Lagrer i databasen

        return newSolider; //returnerer 
    }

    //METODE SOM KAN SLETTE TIL SOLDAT
    [HttpDelete("{id}")] 
    public async Task<IActionResult> Delete(int id)
    {
        Solider solider = await _context.Solider.FindAsync( id );
        _context.Solider.Remove(solider); 
        await _context.SaveChangesAsync();

        return NoContent(); //returnerer 
    }

}