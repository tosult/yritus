using Domain.Base;

namespace Domain.App;

public class JurIsikLiik : DomainEntityId
{
    public int Liik { get; set; }
    
    public ICollection<JurIsik>? JurIsikud { get; set; }
}