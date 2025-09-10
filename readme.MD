# NuGet packages
Microsoft.EntityFrameworkCore
Microsoft.EntityFrameworkCore.Sqlite
Microsoft.EntityFrameworkCore.Design
Automapper
Microsoft.VisualStudio.Web.CodeGeneration.Design
Microsoft.EntityFrameworkCore.Tools
Microsoft.EntityFrameworkCore.SqlServe

# create migration
dotnet ef migrations add Initial --project DAL.EF.App --startup-project WebApp --context ApplicationDbContext

# apply migration
dotnet ef database update --project DAL.EF.App --startup-project WebApp --context ApplicationDbContext

# MVC
dotnet aspnet-codegenerator controller -m Domain.App.Yritus -name YritusedController -outDir Controllers -dc ApplicationDbContext  -udl --referenceScriptLibraries -f