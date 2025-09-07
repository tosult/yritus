using AutoMapper;
using DAL.Base;

namespace Public.DTO.Mappers;

public class JurIsikMapper : BaseMapper<BLL.DTO.JurIsik, Public.DTO.v1.JurIsik>
{
    public JurIsikMapper(IMapper mapper) : base(mapper)
    {
        
    }
}