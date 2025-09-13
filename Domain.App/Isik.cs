using System.ComponentModel.DataAnnotations;
using Domain.Base;
using Microsoft.VisualBasic.CompilerServices;

namespace Domain.App;

public class Isik : DomainEntityId, IValidatableObject
{
    public Guid OsavotumaksId { get; set; }
    public Osavotumaks? Osavotumaks { get; set; }
    
    [Required]
    [MaxLength(64)]
    public string Eesnimi { get; set; }
    
    [Required]
    [MaxLength(64)]
    public string Perenimi { get; set; }
    
    [Required]
    public long Isikukood { get; set; }
    
    [MaxLength(1500)]
    public string? Lisainfo { get; set; }
    
    public ICollection<IsikYritusel>? IsikudYritusel { get; set; }

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        string isikukoodStr = Isikukood.ToString();

        if (isikukoodStr.Length != 11)
        {
            yield return new ValidationResult(
                "Isikukood koosneb 11 numbrist!",
                new[] { nameof(Isikukood) });
            yield break;
        }
        
        string algab = isikukoodStr.Substring(0, 1);
        string kuu = isikukoodStr.Substring(3, 2);
        string paev = isikukoodStr.Substring(5, 2);
        
        if (int.Parse(algab) < 3 || int.Parse(algab) > 6)
        {
            yield return new ValidationResult(
                "Palun kontrolli isikukood!",
                new[] { nameof(Isikukood) });
        }
        if (int.Parse(kuu) < 1 | int.Parse(kuu) > 12)
        {
            yield return new ValidationResult(
                "Palun kontrolli isikukood!",
                new[] { nameof(Isikukood) });
        }

        switch (int.Parse(kuu))
        {
            case 1:
            case 3:
            case 5:
            case 7:
            case 8:
            case 10:
            case 12:
                if (int.Parse(paev) > 31)
                {
                    yield return new ValidationResult(
                        "Palun kontrolli isikukood!",
                        new[] { nameof(Isikukood) });
                }
                break;
            case 4:
            case 6:
            case 9:
            case 11: 
                if (int.Parse(paev) > 30)
                {
                    yield return new ValidationResult(
                        "Palun kontrolli isikukood!",
                        new[] { nameof(Isikukood) });
                }
                break;
            case 2:
                if (int.Parse(paev) > 29)
                {
                    yield return new ValidationResult(
                        "Palun kontrolli isikukood!",
                        new[] { nameof(Isikukood) });
                }
                break;
            default:
                yield return new ValidationResult(
                    "Palun kontrolli isikukood!",
                    new[] { nameof(Isikukood) });
                break;
        }
    }
}