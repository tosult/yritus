using System.ComponentModel.DataAnnotations;
using Domain.Base;

namespace Domain.App;

public class JurIsik : DomainEntityId
{
    public Guid OsavotumaksId { get; set; }
    
    public Guid JurIsikLiikId { get; set; }
    
    [MaxLength(128)]
    public string Nimi { get; set; }
    
    public int Registrikood { get; set; }
    
    [MaxLength(5000)]
    public string? Lisainfo { get; set; }
    
    public ICollection<IsikYritusel>? IsikudYritusel { get; set; }
}