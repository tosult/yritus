namespace Public.DTO.v1;

public class OsavotumaksuStaatus
{
    public Guid Id { get; set; }
    
    public bool Staatus { get; set; }
    
    public ICollection<Osavotumaks>? Osavotumaksud { get; set; }
}