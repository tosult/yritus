using Domain.Base;

namespace Domain.App;

public class JurIsikLiik : DomainEntityId
{
    public string LiikNimetus { get; set; } = default!;
    
    public ICollection<JurIsik>? JurIsikud { get; set; }
}