using Domain.Base;

namespace BLL.DTO;

public class JurIsikLiik : DomainEntityId
{
    public string LiikNimetus { get; set; } = default!;
    
    public ICollection<JurIsik>? JurIsikud { get; set; }
}