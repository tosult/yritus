using AutoMapper;
using BLL.App.Mappers;
using BLL.App.Services;
using BLL.Base;
using BLL.Contracts.App;
using DAL.Contracts.App;

namespace BLL.App;

public class AppBLL : BaseBLL<IAppUOW>, IAppBLL
{
    protected IAppUOW Uow;
    private readonly AutoMapper.IMapper _mapper;

    public AppBLL(IAppUOW uow, IMapper mapper) : base(uow)
    {
        Uow = uow;
        _mapper = mapper;
    }
    
    private IIsikService? _isikService;
    public IIsikService IsikService =>
        _isikService ??= new IsikService(Uow, new IsikMapper(_mapper));
    
    private IIsikYrituselService? _isikYrituselService;
    public IIsikYrituselService IsikYrituselService =>
        _isikYrituselService ??= new IsikYrituselService(Uow, new IsikYrituselMapper(_mapper));
    
    private IIsikYrituselRollService? _isikYrituselRollService;
    public IIsikYrituselRollService IsikYrituselRollService =>
        _isikYrituselRollService ??= new IsikYrituselRollService(Uow, new IsikYrituselRollMapper(_mapper));
    
    private IJurIsikLiikService? _jurIsikLiikService;
    public IJurIsikLiikService JurIsikLiikService =>
        _jurIsikLiikService ??= new JurIsikLiikService(Uow, new JurIsikLiikMapper(_mapper));
    
    private IJurIsikService? _jurIsikService;
    public IJurIsikService JurIsikService =>
        _jurIsikService ??= new JurIsikService(Uow, new JurIsikMapper(_mapper));
    
    private IOsavotumaksService? _osavotumaksService;
    public IOsavotumaksService OsavotumaksService =>
        _osavotumaksService ??= new OsavotumaksService(Uow, new OsavotumaksMapper(_mapper));
    
    private IOsavotumaksuStaatusService? _osavotumaksuStaatusService;
    public IOsavotumaksuStaatusService OsavotumaksuStaatusService =>
        _osavotumaksuStaatusService ??= new OsavotumaksuStaatusService(Uow, new OsavotumaksuStaatusMapper(_mapper));
    
    private ITasumiseViisService? _tasumiseViisService;
    public ITasumiseViisService TasumiseViisService =>
        _tasumiseViisService ??= new TasumiseViisService(Uow, new TasumiseViisMapper(_mapper));
    
    private IYritusService? _yritusService;
    public IYritusService YritusService =>
        _yritusService ??= new YritusService(Uow, new YritusMapper(_mapper));
    
}