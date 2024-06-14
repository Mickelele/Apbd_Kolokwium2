using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace KolosAPBD.Model;

[Table("Character_Titles")]
[PrimaryKey(nameof(CharacterID), nameof(TitleID))]
public class CharacterTitle
{
    public int CharacterID { get; set; }

    public int TitleID { get; set; }

    public DateTime AcquiredAt { get; set; }

    
    [ForeignKey(nameof(CharacterID))]
    public Character Character { get; set; }
    
    [ForeignKey(nameof(TitleID))]
    public Title Title { get; set; }
    
    
}