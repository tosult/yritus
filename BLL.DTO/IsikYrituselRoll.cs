using Domain.Base;

namespace BLL.DTO;

public class IsikYrituselRoll : DomainEntityId
{
    public string RollNimetus { get; set; } = default!;
}