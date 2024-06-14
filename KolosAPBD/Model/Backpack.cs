using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace KolosAPBD.Model;


[PrimaryKey(nameof(CharacterID), nameof(ItemID))]
public class Backpack
{
    public int CharacterID { get; set; }
    
    public int ItemID { get; set; }
    
    public int Amount { get; set; }

    [ForeignKey(nameof(ItemID))]
    public Item Item { get; set; }

    [ForeignKey(nameof(CharacterID))]
    public Character Character { get; set; }
    
}