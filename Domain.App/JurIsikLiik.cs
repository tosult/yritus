using Domain.Base;

namespace Domain.App;

public class JurIsikLiik : DomainEntityId
{
    public string LiikNimetus { get; set; }
    
    public ICollection<JurIsik>? JurIsikud { get; set; }
}