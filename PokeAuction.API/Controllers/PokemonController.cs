using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PokeAuctionAPI.Data;
using PokeAuctionAPI.Models;

namespace PokeAuctionAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PokemonController : ControllerBase
{
    private readonly PokeContext _context;

    public PokemonController(PokeContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Pokemon>>> GetAll()
    {
        return await _context.Pokemon.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Pokemon>> Get(long id)
    {
        var pokemon = await _context.Pokemon.FindAsync(id);
        if (pokemon == null) return NotFound();
        return pokemon;
    }

    [HttpGet("by-dex/{dexNumber}")]
    public async Task<ActionResult<Pokemon>> GetByDex(int dexNumber)
    {
        var pokemon = await _context.Pokemon.FirstOrDefaultAsync(p => p.DexNumber == dexNumber);
        if (pokemon == null) return NotFound($"No Pokémon found with Dex #{dexNumber}");
        return pokemon;
    }

    [HttpGet("debug")]
    public async Task<ActionResult<object>> Debug()
    {
        try
        {
            var totalCount = await _context.Pokemon.CountAsync();
            var firstFew = await _context.Pokemon
                .Take(5)
                .Select(p => new { p.Id, p.DexNumber })
                .ToListAsync();

            var dexOne = await _context.Pokemon
                .Where(p => p.DexNumber == 1)
                .Select(p => new { p.Id, p.DexNumber })
                .ToListAsync();

            return new
            {
                TotalPokemon = totalCount,
                FirstFewPokemon = firstFew,
                DexNumber1Pokemon = dexOne,
                DatabaseConnected = true
            };
        }
        catch (Exception ex)
        {
            return new
            {
                Error = ex.Message,
                DatabaseConnected = false
            };
        }
    }
    [HttpGet("connection-info")]
    public ActionResult<object> GetConnectionInfo()
    {
        var connectionString = _context.Database.GetConnectionString();
        var databaseName = _context.Database.GetDbConnection().Database;

        return new
        {
            ConnectionString = connectionString,
            DatabaseName = databaseName,
            ServerName = _context.Database.GetDbConnection().DataSource
        };
    }
}
