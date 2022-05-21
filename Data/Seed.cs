using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using API_Workshop.Model;

namespace API_Workshop.Data
{
      public static class Seed
      {
            public static async Task SeedLocationAsync(DbxContext context)
            {
                  // if (context.regions.Any()) return;
                  var Data = System.IO.File.ReadAllText("Data/SeedData/Locations.json");
                  var JsonData = JsonSerializer.Deserialize<List<Location>>(Data);

                  foreach (var x in JsonData)
                  {
                        await context.Locations.AddAsync(x);
                  }
                  await context.SaveChangesAsync();
                  Console.WriteLine("Locations Seeding Done");
            }
            public static async Task SeedDepartment(DbxContext context)
            {
                  // if (context.regions.Any()) return;
                  var Data = System.IO.File.ReadAllText("Data/SeedData/Department.json");
                  var JsonData = JsonSerializer.Deserialize<List<department>>(Data);

                  foreach (var x in JsonData)
                  {
                        await context.Departments.AddAsync(x);
                  }
                  await context.SaveChangesAsync();
                  Console.WriteLine("Department Seeding Done");
            }
            public static async Task SeedEmployees(DbxContext context)
            {
                  // if (context.employees.Any()) return;
                  var Data = System.IO.File.ReadAllText("Data/SeedData/Employees.json");
                  var JsonData = JsonSerializer.Deserialize<List<employee>>(Data);

                  foreach (var x in JsonData)
                  {
                        await context.Employees.AddAsync(x);
                  }
                  await context.SaveChangesAsync();
                  Console.WriteLine("Employees Seeding Done");
            }
            public static async Task SeedJobs(DbxContext context)
            {
                  // if (context.jobs.Any()) return;
                  var Data = System.IO.File.ReadAllText("Data/SeedData/Jobs.json");
                  var JsonData = JsonSerializer.Deserialize<List<Jobs>>(Data);

                  foreach (var x in JsonData)
                  {
                        await context.Jobs.AddAsync(x);
                  }
                  await context.SaveChangesAsync();
                  Console.WriteLine("Jobs Seeding Done");
            }

      }

}