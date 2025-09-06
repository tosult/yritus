using Domain.Base;

namespace BLL.DTO;

public class TasumiseViis : DomainEntityId
{
    public int Viis { get; set; }
    
    public ICollection<Osavotumaks>? Osavotumaksud { get; set; }
}