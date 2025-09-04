using Domain.Base;

namespace Domain.App;

public class OsavotumaksuStaatus : DomainEntityId
{
    public bool Staatus { get; set; }
    
    public ICollection<Osavotumaks>? Osavotumaksud { get; set; }
}