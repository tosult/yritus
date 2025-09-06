using Domain.Base;

namespace BLL.DTO;

public class IsikYritusel : DomainEntityId
{
    public Guid YritusId { get; set; }
    
    public Guid? IsikId { get; set; }
    
    public Guid? JurIsikId { get; set; }
}