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
    [HttpGet("evolution/all")]
    public async Task<ActionResult<IEnumerable<Evolution>>> GetAllEvolution()
    {
        return await _pokemonContext.Evolution.ToListAsync();
    }
    [HttpGet("evolution/{pokemonid}")]
    public async Task<ActionResult<object>> GetPokemonEvolution(int pokemonid)
    {
        var pokemon = await _pokemonContext.Pokemon.FirstOrDefaultAsync(p => p.Id == pokemonid);
        if (pokemon == null) return NotFound($"No Pokémon found with ID #{pokemonid}");

        // Check if this pokemon has an evolution (evo_to value)
        if (pokemon.EvoTo == null)
            return Ok(new { message = $"Pokémon does not evolve", pokemon = pokemon });

        // Look for the evolution row where evolved_species_id matches the evo_to value
        var evolution = await _pokemonContext.Evolution
            .FirstOrDefaultAsync(e => e.EvolvedSpeciesId == int.Parse(pokemon.EvoTo)); //should have stored EvoTo as int

        if (evolution == null)
            return NotFound($"Evolution data not found for evolution ID {pokemon.EvoTo}");

        return Ok(new 
        { 
            originalPokemon = pokemon,
            evolutionData = evolution
        });
    }
    /*
    * -----------------------------Item------------------------------------
    */
    [HttpGet("item/all")]
    public async Task<ActionResult<IEnumerable<Item>>> GetAllItems()
    {
        return await _pokemonContext.Item.ToListAsync();
    }

    /*
    * -----------------------------Move Effect Prose-----------------------
    */
    [HttpGet("moveeffectprose/all")]
    public async Task<ActionResult<IEnumerable<Move_effect_prose>>> GetAllMove_effect_prose()
    {
        return await _pokemonContext.Move_effect_prose.ToListAsync();
    }
    /*
    * -----------------------------Move------------------------------------
    */
    [HttpGet("move/all")]
    public async Task<ActionResult<IEnumerable<Move>>> GetAllMove()
    {
        return await _pokemonContext.Move.ToListAsync();
    }

    [HttpGet("moves-detailed/{pokemonid}")]
    public async Task<ActionResult<object>> GetPokemonMovesDetailed(int pokemonid)
    {
        var pokemon = await _pokemonContext.Pokemon.FirstOrDefaultAsync(p => p.Id == pokemonid);
        if (pokemon == null) return NotFound($"No Pokémon found with ID #{pokemonid}");

        var pokemonMovesWithDetails = await _pokemonContext.Pokemon_move
            .Where(pm => pm.PokemonId == pokemonid && pm.VersionGroupId == 25)
            .Join(_pokemonContext.Move,
                pm => pm.MoveId,
                m => m.Id,
                (pm, m) => new
                {
                    VersionGroupId = pm.VersionGroupId,
                    MoveId = m.Id,
                    MoveName = m.Identifier,
                    MovePower = m.Power,
                    MovePP = m.PP,
                    MoveAccuracy = m.Accuracy,
                    MovePriority = m.Priority,
                    LearnLevel = pm.Level,
                    LearnMethod = pm.PokemonMoveMethodId,
                    Order = pm.Order
                })
            .ToListAsync();

        if (!pokemonMovesWithDetails.Any())
            return Ok(new { 
                message = $"No moves found for this Pokémon in version group 25", 
                pokemon = pokemon, 
                moves = new List<object>() 
            });

        return Ok(new
        {
            pokemon = pokemon,
            moves = pokemonMovesWithDetails,
            moveCount = pokemonMovesWithDetails.Count,
            versionGroup = 25
        });
    }

    [HttpGet("moves-detailed/{pokemonid}/version/{versionGroupId}")]
    public async Task<ActionResult<object>> GetPokemonMovesDetailedByVersion(int pokemonid, int versionGroupId)
    {
        var pokemon = await _pokemonContext.Pokemon.FirstOrDefaultAsync(p => p.Id == pokemonid);
        if (pokemon == null) return NotFound($"No Pokémon found with ID #{pokemonid}");

        var pokemonMovesWithDetails = await _pokemonContext.Pokemon_move
            .Where(pm => pm.PokemonId == pokemonid && pm.VersionGroupId == versionGroupId)
            .Join(_pokemonContext.Move,
                pm => pm.MoveId,
                m => m.Id,
                (pm, m) => new
                {
                    VersionGroupId = pm.VersionGroupId,
                    MoveId = m.Id,
                    MoveName = m.Identifier,
                    MovePower = m.Power,
                    MovePP = m.PP,
                    MoveAccuracy = m.Accuracy,
                    MovePriority = m.Priority,
                    LearnLevel = pm.Level,
                    LearnMethod = pm.PokemonMoveMethodId,
                    Order = pm.Order
                })
            .ToListAsync();

        if (!pokemonMovesWithDetails.Any())
            return Ok(new { 
                message = $"No moves found for this Pokémon in version group {versionGroupId}", 
                pokemon = pokemon, 
                moves = new List<object>() 
            });

        return Ok(new
        {
            pokemon = pokemon,
            moves = pokemonMovesWithDetails,
            moveCount = pokemonMovesWithDetails.Count,
            versionGroup = versionGroupId
        });
    }
    /*
        * -----------------------------Pokemon Move----------------------------
        */
        [HttpGet("pokemonmove/all")]
    public async Task<ActionResult<IEnumerable<Pokemon_move>>> GetAllPokemonMove()
    {
        return await _pokemonContext.Pokemon_move.ToListAsync();
    }
    /*
    * -----------------------------Pokemon---------------------------------
    */
    [HttpGet("pokemon/all")]
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

    [HttpGet("info/{pokemonid}")]
    public async Task<ActionResult<Pokemon>> AllPokemonInfo(int pokemonid)
    {
        var pokemon = await _pokemonContext.Pokemon.FirstOrDefaultAsync(p => p.Id == pokemonid);
        if (pokemon == null) return NotFound($"No Pokémon found with ID #{pokemonid}");

        // Check if this pokemon has an evolution (evo_to value)
        if (pokemon.EvoTo == null)
            return Ok(new { message = $"Pokémon does not evolve", pokemon = pokemon });

        // Look for the evolution row where evolved_species_id matches the evo_to value
        var evolution = await _pokemonContext.Evolution
            .FirstOrDefaultAsync(e => e.EvolvedSpeciesId == int.Parse(pokemon.EvoTo)); //should have stored EvoTo as int

        if (evolution == null)
            return NotFound($"Evolution data not found for evolution ID {pokemon.EvoTo}");

         var pokemonMoves = await _pokemonContext.Pokemon_move
            .Where(pm => pm.PokemonId == pokemonid)
            .ToListAsync();

        if (!pokemonMoves.Any())
            return Ok(new { message = $"No moves found for this Pokémon", pokemon = pokemon, moves = new List<Pokemon_move>() });
        return Ok(new
        {
            originalPokemon = pokemon,
            evolutionData = evolution,
            pokemonmoves = pokemonMoves
        });
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
