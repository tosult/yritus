using System.ComponentModel.DataAnnotations;

namespace Public.DTO.v1;

public class Yritus
{
    public Guid Id { get; set; }
    
    [MaxLength(128)]
    public string Nimi { get; set; }
    
    public DateTime Algus { get; set; }
    
    public DateTime Lopp { get; set; }
    
    [MaxLength(128)]
    public string Asukoht { get; set; }
    
    public ICollection<IsikYritusel>?  IsikudYritusel { get; set; }
}