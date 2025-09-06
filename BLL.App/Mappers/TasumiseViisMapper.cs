using AutoMapper;
using DAL.Base;

namespace BLL.App.Mappers;

public class TasumiseViisMapper : BaseMapper<BLL.DTO.TasumiseViis, Domain.App.TasumiseViis>
{
    public TasumiseViisMapper(IMapper mapper) : base(mapper)
    {
    }
}