### Requirements

1. .NET 5 SDK
2. Visual Studio Code
3. SSMS
4. Vscode Extension - C# , Error Lens

## Steps :

1. appsettings.json -
``` json
   "ConnectionStrings": {
         "API": "Server=VINOTH\\SQLEXPRESS;Database=API_Workshop;Trusted_Connection=True;"
   }
```

2. Update csproj
```xml
<PackageReference Include="Swashbuckle.AspNetCore" Version="5.6.3" />
<PackageReference Include="Microsoft.EntityFrameworkCore" Version="5.0.10" />
<PackageReference Include="Microsoft.EntityFrameworkCore.Design" Version="5.0.10" />
<PackageReference Include="Microsoft.EntityFrameworkCore.SqlServer" Version="5.0.10" />
```

3. Add Context class

```c#
namespace API_Workshop.Data
{
      public class DbxContext : DbContext
      {
            public DbxContext(DbContextOptions<DbxContext> options) : base(options) { }
            public DbSet<employee> Employees { get; set; }
      }
}

```

4. Startup.cs  (Add SQL Server Config)
```c#
// ConfigureServices Method
services.AddDbContext<DbxContext>(o => o.UseSqlServer(Configuration.GetConnectionString("API")));
services.AddCors();

// Configure Methods (next to UseRouting())
app.UseCors(x => x.AllowAnyHeader().WithMethods().AllowAnyOrigin());
```

5. Program.cs

```c#
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
            await Seed.SeedLocationAsync(con);
            await Seed.SeedDepartment(con);
            await Seed.SeedJobs(con);
            await Seed.SeedEmployees(con);
      }
      catch (Exception ex)
      {
            var logger = services.GetRequiredService<ILogger<Program>>();
            logger.LogError(ex, "An error occurred during migration");
      }
      await build.RunAsync();
}
```
### Important Command
#### Entity Frameworks CMD
```bash
dotnet watch run
dotnet-ef migrations add hello && dotnet-ef database update
dotnet-ef database drop 
```
