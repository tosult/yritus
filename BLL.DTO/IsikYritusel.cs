using Domain.Base;

namespace BLL.DTO;

public class IsikYritusel : DomainEntityId
{
    public Guid YritusId { get; set; }
    public Yritus? Yritus { get; set; }
    
    public Guid? IsikId { get; set; }
    public Isik? Isik { get; set; }
    
    public Guid? JurIsikId { get; set; }
    public JurIsik? JurIsik { get; set; }
}