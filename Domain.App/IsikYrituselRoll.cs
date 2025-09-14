using Domain.Base;

namespace Domain.App;

public class IsikYrituselRoll : DomainEntityId
{
    public string RollNimetus { get; set; } = default!;
}