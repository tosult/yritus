namespace Public.DTO.v1;

public class IsikYritusel
{
    public Guid Id { get; set; }
    
    public Guid YritusId { get; set; }
    
    public Guid? IsikId { get; set; }
    
    public Guid? JurIsikId { get; set; }
}