dotnet core 5 SDK
Vscode ,
SSMS ,

Vscode Extension , C#

Steps :

1. appsettings.json -
   "ConnectionStrings": {
   "API": "Server=VINOTH\\SQLEXPRESS;Database=API_Workshop;Trusted_Connection=True;"
   }

### ---**---**---**---**---**---**---**---**---

2. Update csproj

<PackageReference Include="Swashbuckle.AspNetCore" Version="5.6.3" />
<PackageReference Include="Microsoft.EntityFrameworkCore" Version="5.0.10" />
<PackageReference Include="Microsoft.EntityFrameworkCore.Design" Version="5.0.10" />
<PackageReference Include="Microsoft.EntityFrameworkCore.SqlServer" Version="5.0.10" />

### ---**---**---**---**---**---**---**---**---

3. Add Context class

### ---**---**---**---**---**---**---**---**---

4. Add SQL Server Config

services.AddDbContext<DbxContext>(o => o.UseSqlServer(Configuration.GetConnectionString("API")));
services.AddCors();

### ---**---**---**---**---**---**---**---**---

5. Update Program.cs

public static async Task Main(string[] args)
{
var build = CreateHostBuilder(args).Build();
using var scope = build.Services.CreateScope();
var services = scope.ServiceProvider;
try
{
var con = services.GetRequiredService<DbxContext>();
con.Database.Migrate();
// Run Once Only On Start

            // await Seed.SeedLocationAsync(con);
            // await Seed.SeedDepartment(con);
            // await Seed.SeedJobs(con);
            // await Seed.SeedEmployees(con);
      }
      catch (Exception ex)
      {
            var logger = services.GetRequiredService<ILogger<Program>>();
            logger.LogError(ex, "An error occurred during migration");
      }

      await build.RunAsync();

}

### ---**---**---**---**---**---**---**---**---

dotnet watch run
dotnet-ef migrations add hello && dotnet-ef database update
dotnet-ef database drop && dotnet-ef migrations add hello && dotnet-ef database update
