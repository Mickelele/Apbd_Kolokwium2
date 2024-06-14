using System.ComponentModel.DataAnnotations;

namespace KolosAPBD.Model;

public class Title
{
    [Key]
    public int TitleID { get; set; }
    
    [MaxLength(100)]
    public string Name { get; set; }

    public ICollection<CharacterTitle> CharacterTitles { get; set; } = new HashSet<CharacterTitle>();
}