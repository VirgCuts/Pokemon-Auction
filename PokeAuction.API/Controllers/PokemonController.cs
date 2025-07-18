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

    public PokemonController(PokemonContext pokemonContext)
    {
        _pokemonContext = pokemonContext;
    }

    /*
    * -----------------------------Evolution-------------------------------
    */
    [HttpGet("all/evolution")]
    public async Task<ActionResult<IEnumerable<Evolution>>> GetAllEvolution()
    {
        return await _pokemonContext.Evolution.ToListAsync();
    }
    /*
    * -----------------------------Item------------------------------------
    */
    [HttpGet("all/item")]
    public async Task<ActionResult<IEnumerable<Item>>> GetAllItems()
    {
        return await _pokemonContext.Item.ToListAsync();
    }

    /*
    * -----------------------------Move Effect Prose-----------------------
    */
    [HttpGet("all/moveeffectprose")]
    public async Task<ActionResult<IEnumerable<Move_effect_prose>>> GetAllMove_effect_prose()
    {
        return await _pokemonContext.Move_effect_prose.ToListAsync();
    }
    /*
    * -----------------------------Move------------------------------------
    */
    [HttpGet("all/move")]
    public async Task<ActionResult<IEnumerable<Move>>> GetAllMove()
    {
        return await _pokemonContext.Move.ToListAsync();
    }
    /*
    * -----------------------------Pokemon Move----------------------------
    */
    [HttpGet("all/pokemonmove")]
    public async Task<ActionResult<IEnumerable<Pokemon_move>>> GetAllPokemonMove()
    {
        return await _pokemonContext.Pokemon_move.ToListAsync();
    }
    /*
    * -----------------------------Pokemon---------------------------------
    */
    [HttpGet("all/pokemon")]
    public async Task<ActionResult<IEnumerable<Pokemon>>> GetAllPokemon()
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
    * -----------------------------Debug Calls------------------------------
    */
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
