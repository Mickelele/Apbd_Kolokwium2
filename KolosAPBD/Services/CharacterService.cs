using KolosAPBD.Context;
using KolosAPBD.DTO_s;
using KolosAPBD.Model;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KolosAPBD.Services;

public class CharacterService
{

    private readonly ApbdContext _context;

    public CharacterService(ApbdContext context)
    {
        _context = context;
    }
    
    
    public async Task<GETCharacterDTO> GetCharacterINFO(int id)
    {
        var character = await _context.Characters
            .Include(c => c.Backpacks)
            .ThenInclude(b => b.Item)
            .Include(c => c.CharacterTitles)
            .ThenInclude(ct => ct.Title)
            .Where(c => c.CharacterID == id)
            .FirstAsync();


        var result = new GETCharacterDTO()
        {
            FirstName = character.FirstName,
            LastName = character.LastName,
            CurrentWeight = character.CurrentWeight,
            MaxWeight = character.MaxWeight,
            Backpacks = character.Backpacks.Select(b => new GETBackpackDTO()
            {
                ItemName = b.Item.Name,
                ItemWeight = b.Item.Weight,
                Amount = b.Amount
            }).ToList(),
            Titles = character.CharacterTitles.Select(ct => new GETTitleDTO()
            {
                Name = ct.Title.Name,
                AquiredAt = ct.AcquiredAt
            }).ToList()
        };

        return result;
    }
    
    
    
    public async Task<bool> CzyCharacterIstnieje(int id)
    {
        return await _context.Characters.AnyAsync(c => c.CharacterID == id);
    }
    
    
    
    public async Task AddItemsToBackpack(int characterID, [FromBody]ADDItemDTO items)
    {
        var character = await _context.Characters
            .Include(c => c.Backpacks)
            .FirstAsync(c => c.CharacterID == characterID);
        
        int suma = 0;
        foreach (var item in items.Items)
        {
            var i = await _context.Items.FirstAsync(i => i.Id == item.ItemID);
            var existingItem = character.Backpacks.FirstOrDefault(b => b.ItemID == item.ItemID);
            if (existingItem != null)
            {
                existingItem.Amount += 1;
            }
            else
            {
                var newBackpackPosition = new Backpack()
                {
                    CharacterID = characterID,
                    ItemID = item.ItemID,
                    Amount = 1
                };
                character.Backpacks.Add(newBackpackPosition);
            }

            suma += i.Weight;
        }
        
        character.CurrentWeight += suma;

        await _context.SaveChangesAsync();
        
    }
    
    
    public async Task<int> CzyPrzedmiotIstnieje(ADDItemDTO items)
    {
        foreach (var i in items.Items)
        {
            if (!(await _context.Items.AnyAsync(a => a.Id == i.ItemID)))
            {
                return i.ItemID;
            }
        }

        return 0;
    }
    
    
    public async Task<bool> CzyWystarczyMiejsca(int characterID, ADDItemDTO items)
    {
        var character = await _context.Characters.FirstAsync(c => c.CharacterID == characterID);
        var wolneMiejsce = character.MaxWeight - character.CurrentWeight;
        int suma = 0;
        foreach (var i in items.Items)
        {
            var curItem = await _context.Items.FirstAsync(a => a.Id == i.ItemID);
            suma += curItem.Weight;
        }

        if (suma > wolneMiejsce)
        {
            return false;
        }

        return true;
    }
    
    

}