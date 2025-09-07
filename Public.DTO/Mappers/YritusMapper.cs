using AutoMapper;
using DAL.Base;

namespace Public.DTO.Mappers;

public class YritusMapper : BaseMapper<BLL.DTO.Yritus, Public.DTO.v1.Yritus>
{
    public YritusMapper(IMapper mapper) : base(mapper)
    {
        
    }
}