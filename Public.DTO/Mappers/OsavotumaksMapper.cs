using AutoMapper;
using DAL.Base;

namespace Public.DTO.Mappers;

public class OsavotumaksMapper : BaseMapper<BLL.DTO.Osavotumaks, Public.DTO.v1.Osavotumaks>
{
    public OsavotumaksMapper(IMapper mapper) : base(mapper)
    {

    }
}