using AutoMapper;
using DAL.Base;

namespace Public.DTO.Mappers;

public class IsikMapper : BaseMapper<BLL.DTO.Isik, Public.DTO.v1.Isik>
{
    public IsikMapper(IMapper mapper) : base(mapper)
    {
        
    }
}