using Domain.App;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApp.Models;

public class IsikCreateViewModel
{
    public Isik isik { get; set; }
    
    public Guid selectTasumiseViisId { get; set; }
    public IEnumerable<SelectListItem>? TasumiseViisid { get; set; }
}