using DAL.Contracts.App;
using DAL.EF.App.Repositorites;
using DAL.EF.Base;

namespace DAL.EF.App;

public class AppUOW : EFBaseUOW<ApplicationDbContext>, IAppUOW
{
    public AppUOW(ApplicationDbContext dataContext) : base(dataContext)
    {
    }
    
    private IIsikRepository? _isikRepository;
    public IIsikRepository IsikRepository =>
        _isikRepository ??= new IsikRepository(UowDbContext);
    
    private IIsikYrituselRepository? _isikYrituselRepository;
    public IIsikYrituselRepository IsikYrituselRepository =>
        _isikYrituselRepository ??= new IsikYrituselRepository(UowDbContext);
    
    private IIsikYrituselRollRepository? _isikYrituselRollRepository;
    public IIsikYrituselRollRepository IsikYrituselRollRepository =>
        _isikYrituselRollRepository ??= new IsikYrituselRollRepository(UowDbContext);
    
    private IJurIsikLiikRepository? _jurIsikLiikRepository;
    public IJurIsikLiikRepository JurIsikLiikRepository =>
        _jurIsikLiikRepository ??= new JurIsikLiikRepository(UowDbContext);
    
    private IJurIsikRepository? _jurIsikRepository;
    public IJurIsikRepository JurIsikRepository =>
        _jurIsikRepository ??= new JurIsikRepository(UowDbContext);
    
    private IOsavotumaksRepository? _osavotumaksRepository;
    public IOsavotumaksRepository OsavotumaksRepository =>
        _osavotumaksRepository ??= new OsavotumaksRepository(UowDbContext);
    
    private IOsavotumaksuStaatusRepository? _osavotumaksuStaatusRepository;
    public IOsavotumaksuStaatusRepository OsavotumaksuStaatusRepository =>
        _osavotumaksuStaatusRepository ??= new OsavotumaksuStaatusRepository(UowDbContext);
    
    private ITasumiseViisRepository? _tasumiseViisRepository;
    public ITasumiseViisRepository TasumiseViisRepository =>
        _tasumiseViisRepository ??= new TasumiseViisRepository(UowDbContext);
    
    private IYritusRepository? _yritusRepository;
    public IYritusRepository YritusRepository =>
        _yritusRepository ??= new YritusRepository(UowDbContext);
}