using AutoMapper;
using DAL.Base;

namespace Public.DTO.Mappers;

public class JurIsikLiikMapper : BaseMapper<BLL.DTO.JurIsikLiik, Public.DTO.v1.JurIsikLiik>
{
    public JurIsikLiikMapper(IMapper mapper) : base(mapper)
    {

    }
}