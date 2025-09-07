namespace Public.DTO.v1;

public class JurIsikLiik
{
    public Guid Id { get; set; }
    
    public string LiikNimetus { get; set; }
    
    public ICollection<JurIsik>? JurIsikud { get; set; }
}