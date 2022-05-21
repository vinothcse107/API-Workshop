using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using API_Workshop.Model;


namespace API_Workshop.Data
{
      public class DbxContext : DbContext
      {
            public DbxContext(DbContextOptions<DbxContext> options) : base(options) { }
            public DbSet<employee> Employees { get; set; }
            public DbSet<department> Departments { get; set; }
            public DbSet<Jobs> Jobs { get; set; }
            public DbSet<Location> Locations { get; set; }

      }
}