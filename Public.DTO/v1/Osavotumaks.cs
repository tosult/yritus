namespace Public.DTO.v1;

public class Osavotumaks
{
    public Guid Id { get; set; }
    
    public Guid OsavotumaksuStaatusId { get; set; }
    
    public Guid TasumiseViisId { get; set; }
    
    public ICollection<Isik>? Isikud  { get; set; }
    
    public ICollection<JurIsik>? JurIsikud { get; set; }
}