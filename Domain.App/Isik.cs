using System.ComponentModel.DataAnnotations;
using Domain.Base;

namespace Domain.App;

public class Isik : DomainEntityId
{
    public Guid OsavotumaksId { get; set; }
    public Osavotumaks? Osavotumaks { get; set; }
    
    [MaxLength(64)]
    public string Eesnimi { get; set; }
    
    [MaxLength(64)]
    public string Perenimi { get; set; }
    
    public long Isikukood { get; set; }
    
    [MaxLength(1500)]
    public string? Lisainfo { get; set; }
    
    public ICollection<IsikYritusel>? IsikudYritusel { get; set; }
}