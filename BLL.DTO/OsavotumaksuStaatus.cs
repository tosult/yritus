using Domain.Base;

namespace BLL.DTO;

public class OsavotumaksuStaatus : DomainEntityId
{
    public bool Staatus { get; set; }
    
    public ICollection<Osavotumaks>? Osavotumaksud { get; set; }
}