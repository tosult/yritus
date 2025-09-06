using System.ComponentModel.DataAnnotations;
using Domain.Base;

namespace BLL.DTO;

public class Yritus : DomainEntityId
{
    [MaxLength(128)]
    public string Nimi { get; set; }
    
    public DateTime Algus { get; set; }
    
    public DateTime Lopp { get; set; }
    
    [MaxLength(128)]
    public string Asukoht { get; set; }
    
    public ICollection<IsikYritusel>?  IsikudYritusel { get; set; }
}