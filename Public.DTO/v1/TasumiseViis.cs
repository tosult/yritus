namespace Public.DTO.v1;

public class TasumiseViis
{
    public Guid Id { get; set; }
    
    public string ViisNimetus { get; set; }
    
    public ICollection<Osavotumaks>? Osavotumaksud { get; set; }
}