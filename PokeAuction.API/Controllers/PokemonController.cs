using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PokeAuctionAPI.Data;
using PokeAuctionAPI.Models;

namespace PokeAuctionAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PokemonController : ControllerBase
{
    private readonly PokemonContext _pokemonContext;
    private readonly ItemContext _ItemContext;
    private readonly MoveContext _MoveContext;
    private readonly PokemonMoveContext _pokemonMoveContext;
    private readonly EvolutionContext _evolutionContext;

    public PokemonController(
        PokemonContext pokemonContext,
        ItemContext ItemContext,
        MoveContext MoveContext,
        PokemonMoveContext pokemonMoveContext,
        EvolutionContext evolutionContext)
    {
        _pokemonContext = pokemonContext;
        _ItemContext = ItemContext;
        _MoveContext = MoveContext;
        _pokemonMoveContext = pokemonMoveContext;
        _evolutionContext = evolutionContext;
    }
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Pokemon>>> GetAll()
    {
        return await _pokemonContext.Pokemon.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Pokemon>> Get(long id)
    {
        var pokemon = await _pokemonContext.Pokemon.FindAsync(id);
        if (pokemon == null) return NotFound();
        return pokemon;
    }

    [HttpGet("by-dex/{dexNumber}")]
    public async Task<ActionResult<Pokemon>> GetByDex(int dexNumber)
    {
        var pokemon = await _pokemonContext.Pokemon.FirstOrDefaultAsync(p => p.DexNumber == dexNumber);
        if (pokemon == null) return NotFound($"No Pokémon found with Dex #{dexNumber}");
        return pokemon;
    }

    /*
    * --------------------------------------ITEM-----------------------------------
    */

    [HttpGet("items")]
        public async Task<ActionResult<IEnumerable<Item>>> GetItems()
        {
            try
            {
                var items = await _ItemContext.Item.ToListAsync();
                return Ok(items);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while retrieving items", error = ex.Message });
            }
        }


    [HttpGet("debug")]
    public async Task<ActionResult<object>> Debug()
    {
        try
        {
            var totalCount = await _pokemonContext.Pokemon.CountAsync();
            var firstFew = await _pokemonContext.Pokemon
                .Take(5)
                .Select(p => new { p.Id, p.DexNumber })
                .ToListAsync();

            var dexOne = await _pokemonContext.Pokemon
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
        var connectionString = _pokemonContext.Database.GetConnectionString();
        var databaseName = _pokemonContext.Database.GetDbConnection().Database;

        return new
        {
            ConnectionString = connectionString,
            DatabaseName = databaseName,
            ServerName = _pokemonContext.Database.GetDbConnection().DataSource
        };
    }
}
