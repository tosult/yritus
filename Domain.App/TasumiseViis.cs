using Domain.Base;

namespace Domain.App;

public class TasumiseViis : DomainEntityId
{
    public int Viis { get; set; }
    
    public ICollection<Osavotumaks>? Osavotumaksud { get; set; }
}