using Domain.Base;

namespace BLL.DTO;

public class JurIsikLiik : DomainEntityId
{
    public string LiikNimetus { get; set; }
    
    public ICollection<JurIsik>? JurIsikud { get; set; }
}