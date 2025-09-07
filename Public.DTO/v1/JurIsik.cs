using System.ComponentModel.DataAnnotations;

namespace Public.DTO.v1;

public class JurIsik
{
    public Guid Id { get; set; }
    
    public Guid OsavotumaksId { get; set; }
    
    public Guid JurIsikLiikId { get; set; }
    
    [MaxLength(128)]
    public string Nimi { get; set; }
    
    public int Registrikood { get; set; }
    
    [MaxLength(5000)]
    public string? Lisainfo { get; set; }
    
    public ICollection<IsikYritusel>? IsikudYritusel { get; set; }
}