using Domain.Base;

namespace BLL.DTO;

public class TasumiseViis : DomainEntityId
{
    public string ViisNimetus { get; set; }
    
    public ICollection<Osavotumaks>? Osavotumaksud { get; set; }
}