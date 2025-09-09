using BLL.App;
using BLL.Contracts.App;
using DAL.Contracts.App;
using DAL.EF.App;
using DAL.EF.App.Seeding;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ??
                       throw new InvalidOperationException("Connection string 'DefaultConnection' not found");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(connectionString));

builder.Services.AddScoped<IAppUOW, AppUOW>();
builder.Services.AddScoped<IAppBLL, AppBLL>();

builder.Services.AddControllersWithViews();

builder.Services.AddAutoMapper(cfg =>
    {
        cfg.AddMaps(typeof(BLL.App.AutoMapperConfig).Assembly);
    }
);

var app = builder.Build();

SetupAppData(app, app.Configuration);

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();

static void SetupAppData(IApplicationBuilder app, IConfiguration configuration)
{
    using var serviceScope = app.ApplicationServices
        .GetRequiredService<IServiceScopeFactory>()
        .CreateScope();
    
    using var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();

    if (context == null)
    {
        throw new ApplicationException("Database context not found");
    }

    var logger = serviceScope.ServiceProvider.GetService<ILogger<IApplicationBuilder>>();

    if (logger == null)
    {
        throw new ApplicationException("Logger not found");
    }

    if (configuration.GetValue<bool>("DataInit:DropDatabase"))
    {
        logger.LogWarning("Dropping database!");
    }
    
    if (configuration.GetValue<bool>("DataInit:MigrateDatabase"))
    {
        logger.LogWarning("Migrating database!");
        AppDataInit.MigrateDataBase(context);
    }
    
    if (configuration.GetValue<bool>("DataInit:SeedData"))
    {
        logger.LogWarning("Seeding initial data!");
        AppDataInit.SeedAppData(context);
    }
}