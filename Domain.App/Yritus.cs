using Domain.Base;

namespace Domain.App;

public class Yritus : DomainEntityId
{
    public string Nimi { get; set; }
    
    public DateTime Algus { get; set; }
    
    public DateTime Lopp { get; set; }
    
    public string Asukoht { get; set; }
    
    public ICollection<IsikYritusel>?  IsikudYritusel { get; set; }
}