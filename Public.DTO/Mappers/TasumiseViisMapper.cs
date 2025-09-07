using AutoMapper;
using DAL.Base;

namespace Public.DTO.Mappers;

public class TasumiseViisMapper : BaseMapper<BLL.DTO.TasumiseViis, Public.DTO.v1.TasumiseViis>
{
    public TasumiseViisMapper(IMapper mapper) : base(mapper)
    {

    }
}