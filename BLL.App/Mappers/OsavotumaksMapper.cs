using AutoMapper;
using DAL.Base;

namespace BLL.App.Mappers;

public class OsavotumaksMapper : BaseMapper<BLL.DTO.Osavotumaks, Domain.App.Osavotumaks>
{
    public OsavotumaksMapper(IMapper mapper) : base(mapper)
    {
    }
}