using Domain.Base;

namespace BLL.DTO;

public class JurIsikLiik : DomainEntityId
{
    public int Liik { get; set; }
    
    public ICollection<JurIsik>? JurIsikud { get; set; }
}