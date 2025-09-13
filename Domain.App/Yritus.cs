using System.ComponentModel.DataAnnotations;
using Domain.Base;

namespace Domain.App;

public class Yritus : DomainEntityId, IValidatableObject
{
    [Required]
    [MaxLength(128)]
    public string Nimi { get; set; }
    
    [Required]
    public DateTime Algus { get; set; }
    
    [Required]
    public DateTime Lopp { get; set; }
    
    [Required]
    [MaxLength(128)]
    public string Asukoht { get; set; }
    
    public ICollection<IsikYritusel>?  IsikudYritusel { get; set; }

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (Algus < DateTime.Now)
        {
            yield return new ValidationResult(
                "Algus peab olema tulevikus!",
            new[] {nameof(Algus)});
        }
        
        if (Lopp < DateTime.Now)
        {
            yield return new ValidationResult(
                "Lõpp peab olema tulevikus!",
                new[] {nameof(Algus)});
        }
        if (Lopp <= Algus)
        {
            yield return new ValidationResult(
                "Lõpp ei saa olla enne algust!",
                new[] {nameof(Algus)});
        }
    }
}