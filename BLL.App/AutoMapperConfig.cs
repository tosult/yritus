using AutoMapper;

namespace BLL.App;

public class AutoMapperConfig : Profile
{
    public AutoMapperConfig()
    {
        CreateMap<BLL.DTO.Isik, Domain.App.Isik>().ReverseMap();
        CreateMap<BLL.DTO.IsikYritusel, Domain.App.IsikYritusel>().ReverseMap();
        CreateMap<BLL.DTO.IsikYrituselRoll, Domain.App.IsikYrituselRoll>().ReverseMap();
        CreateMap<BLL.DTO.JurIsik, Domain.App.JurIsik>().ReverseMap();
        CreateMap<BLL.DTO.JurIsikLiik, Domain.App.JurIsikLiik>().ReverseMap();
        CreateMap<BLL.DTO.Osavotumaks, Domain.App.Osavotumaks>().ReverseMap();
        CreateMap<BLL.DTO.OsavotumaksuStaatus, Domain.App.OsavotumaksuStaatus>().ReverseMap();
        CreateMap<BLL.DTO.TasumiseViis, Domain.App.TasumiseViis>().ReverseMap();
        CreateMap<BLL.DTO.Yritus, Domain.App.Yritus>().ReverseMap();
    }
}