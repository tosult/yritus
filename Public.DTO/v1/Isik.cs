using System.ComponentModel.DataAnnotations;

namespace Public.DTO.v1;

public class Isik
{
    public Guid id { get; set; }
    
    public Guid OsavotumaksId { get; set; }
    public Osavotumaks? Osavotumaks { get; set; }
    
    [MaxLength(64)]
    public string Eesnimi { get; set; }
    
    [MaxLength(64)]
    public string Perenimi { get; set; }
    
    public int Isikukood { get; set; }
    
    [MaxLength(1500)]
    public string? Lisainfo { get; set; }
    
    public ICollection<IsikYritusel>? IsikudYritusel { get; set; }
}