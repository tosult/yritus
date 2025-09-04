using Domain.Base;

namespace Domain.App;

public class Isik : DomainEntityId
{
    public Guid OsavotumaksId { get; set; }
    
    public string Eesnimi { get; set; }
    
    public string Perenimi { get; set; }
    
    public int Isikukood { get; set; }
    
    public string? Lisainfo { get; set; }
    
    public ICollection<IsikYritusel>? IsikudYritusel { get; set; }
}