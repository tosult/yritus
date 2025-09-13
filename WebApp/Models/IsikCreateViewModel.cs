using Domain.App;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApp.Models;

public class IsikCreateViewModel
{
    public Isik Isik { get; set; }
    
    public Guid SelectTasumiseViisId { get; set; }
    public IEnumerable<SelectListItem>? TasumiseViisid { get; set; }
    
    public Guid YritusId { get; set; }
}