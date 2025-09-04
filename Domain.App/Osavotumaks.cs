using Domain.Base;

namespace Domain.App;

public class Osavotumaks : DomainEntityId
{
    public Guid OsavotumaksuStaatusId { get; set; }
    
    public Guid TasumiseViisId { get; set; }
    
    public ICollection<Isik>? Isikud  { get; set; }
    
    public ICollection<JurIsik>? JurIsikud { get; set; }
}