using AutoMapper;
using DAL.Base;

namespace Public.DTO.Mappers;

public class IsikYrituselMapper : BaseMapper<BLL.DTO.IsikYritusel, Public.DTO.v1.IsikYritusel>
{
    public IsikYrituselMapper(IMapper mapper) : base(mapper)
    {
        
    }
}