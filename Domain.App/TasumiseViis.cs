using Domain.Base;

namespace Domain.App;

public class TasumiseViis : DomainEntityId
{
    public string ViisNimetus { get; set; } = default!;
    
    public ICollection<Osavotumaks>? Osavotumaksud { get; set; }
}