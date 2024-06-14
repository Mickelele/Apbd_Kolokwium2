using KolosAPBD.Model;

namespace KolosAPBD.DTO_s;

public class GETCharacterDTO
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int CurrentWeight { get; set; }
    public int MaxWeight { get; set; }
    public ICollection<GETBackpackDTO> Backpacks { get; set; } = null!;

    public ICollection<GETTitleDTO> Titles { get; set; } = null!;
}