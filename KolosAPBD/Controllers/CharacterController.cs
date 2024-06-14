using KolosAPBD.DTO_s;
using KolosAPBD.Services;
using Microsoft.AspNetCore.Mvc;

namespace KolosAPBD.Controllers;


[ApiController]
[Route("api/characters")]
public class CharacterController : ControllerBase
{

    private readonly CharacterService _characterService;

    public CharacterController(CharacterService characterService)
    {
        _characterService = characterService;
    }

    
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetCharacterInfo(int id)
    {
        if (!await _characterService.CzyCharacterIstnieje(id))
        {
            return NotFound($"Character o id {id} nie istnieje.");
        }

        var result = await _characterService.GetCharacterINFO(id);

        return Ok(result);
    }
    
    
    [HttpPost("{characterID}/backpacks")]
    public async Task<IActionResult> AddItemsToBackpack(int characterID, ADDItemDTO items)
    {
        if (!await _characterService.CzyCharacterIstnieje(characterID))
        {
            return NotFound($"Character o id {characterID} nie istnieje.");
        }

        var przedmiot = await _characterService.CzyPrzedmiotIstnieje(items);
        if (przedmiot != 0)
        {
            return NotFound($"Przedmiot o id {przedmiot} nie istnieje");
        }
        
        if (!await _characterService.CzyWystarczyMiejsca(characterID, items))
        {
            return BadRequest($"Character nie uniesie tylu przedmiotow. Waga przekroczona");
        }

        await _characterService.AddItemsToBackpack(characterID, items);
        return StatusCode(201);
    }

    
    


}