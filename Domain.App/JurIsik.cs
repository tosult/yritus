using Domain.Base;

namespace Domain.App;

public class JurIsik : DomainEntityId
{
    public Guid OsavotumaksId { get; set; }
    
    public Guid JurIsikLiikId { get; set; }
    
    public string Nimi { get; set; }
    
    public int Registrikood { get; set; }
    
    public string? Lisainfo { get; set; }
    
    public ICollection<IsikYritusel>? IsikudYritusel { get; set; }
}