namespace KolosAPBD.DTO_s;

public class ADDItemDTO
{
    public ICollection<ADDItemDTO2> Items { get; set; }
}

public class ADDItemDTO2
{
    public int ItemID { get; set; }
}