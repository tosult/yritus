using AutoMapper;
using DAL.Base;

namespace Public.DTO.Mappers;

public class IsikYrituselRollMapper : BaseMapper<BLL.DTO.IsikYrituselRoll, Public.DTO.v1.IsikYrituselRoll>
{
    public IsikYrituselRollMapper(IMapper mapper) : base(mapper)
    {
        
    }
}