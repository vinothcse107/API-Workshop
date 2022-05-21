using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_Workshop.Data;
using API_Workshop.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_Workshop.Controllers
{
      [ApiController]
      [Route("[controller]")]
      public class LinqController : ControllerBase
      {
            private DbxContext _context { get; }

            public LinqController(DbxContext context)
            {
                  _context = context;
            }
            [HttpGet("Find/{id}")]
            public IActionResult Find(int id)
            {
                  var x = _context.Employees.FindAsync(id);
                  return Ok(x);
            }

            [HttpGet("SelectAll")]
            public IActionResult SelectAll()
            {
                  var x = _context.Departments.Select(s => s);
                  return Ok(x);
            }

            // From the following table, write a SQL query to find the details of 'Marketing'
            //  department.Return all fields.

            [HttpGet("Get_Salary_Less_Than_6000")]
            public async Task<IActionResult> SelectObject()
            {
                  // 1. Deferred Execution
                  var y = await (from e in _context.Employees
                                 where e.salary < 6000
                                 select new
                                 {
                                       FullName = $"{e.First_Name} {e.Last_Name}",
                                       Salary = e.salary
                                 }).ToListAsync();

                  // 2. Immediate Execution
                  var x = await _context.Employees
                              .Where(w => w.salary < 6000)
                              .Select(s => new
                              {
                                    FullName = s.First_Name + " " +
                                    s.Last_Name,
                                    Salary = s.salary
                              })
                              .ToListAsync();

                  return Ok(x);
            }

            [HttpGet("Get_FirstName_Not_M")]
            public async Task<IActionResult> OrderBy()
            {
                  var x = await _context.Employees
                              .Where(w => !w.First_Name.Contains("M"))
                              .OrderBy(x => x.Department_ID)
                              .Select(s => new
                              {
                                    FullName = s.First_Name + " " + s.Last_Name,
                                    Hire_Date = s.Hire_Date,
                                    Salary = s.salary,
                                    Department_Id = s.Department_ID
                              })
                              .ToListAsync();
                  return Ok(x);
            }

            [HttpGet("Joins_Departmetnt_Location")]
            public async Task<IActionResult> Join()
            {
                  var x = await (from e in _context.Employees
                                 join d in _context.Departments on e.Department_ID equals d.Department_ID
                                 join l in _context.Locations on d.Location_ID equals l.Location_Id
                                 select new { e, d, l })
                              .Select(s => new
                              {
                                    FullName = $"{s.e.First_Name} {s.e.Last_Name}",
                                    Hire_Date = s.e.Hire_Date,
                                    Salary = s.e.salary,
                                    Department_Name = s.d.Department_Name,
                                    Location = s.l.City

                              })
                              .ToListAsync();
                  return Ok(x);
            }

            [HttpGet("Lookup_Departmetnt")]
            public IActionResult Lookup()
            {
                  var x = (from e in _context.Employees
                           join d in _context.Departments on e.Department_ID equals d.Department_ID
                           select new { e, d })
                              .ToLookup(g => g.d.Department_Name)
                              .Select(s => new
                              {
                                    Key = s.Key,
                                    Employees = s.Select(g => new
                                    {
                                          FullName = $"{g.e.First_Name} {g.e.Last_Name}",
                                          Salary = g.e.salary,
                                    })
                              });
                  return Ok(x);
            }

            // ToLookup - Immediate Execution
            // GroupBy - Deferred Execution

            // GroupBy Can Manipulate On List because of Deferred Execution
            [HttpGet("GroupBy_Departmetnt")]
            public IActionResult GroupBy()
            {
                  var y = _context.Employees.ToList()
                        .GroupBy(g => g.Department_ID)
                        .Select(r => new
                        {
                              Key = r.Key,
                              Value = r.Select(s => s.First_Name)
                        }).ToList();

                  return Ok(y);
            }

            [HttpGet("First_Filter")]
            public IActionResult First_Filter()
            {
                  var a = _context.Employees.First();
                  var c = _context.Employees.OrderBy(o => o.EmployeeID).Last();
                  var d = _context.Employees.OrderBy(o => o.EmployeeID).LastOrDefault(p => p.EmployeeID > 210);
                  var e = _context.Employees.Select(s => s).ToList().ElementAt<employee>(2);
                  var f = _context.Employees.All(o => o.EmployeeID >= 100);
                  var g = _context.Employees.Any(o => o.EmployeeID == 5);
                  var i = _context.Employees.Take(3);

                  return Ok(new
                  {
                        First = a,
                        Last = c,
                        LastOrDefault = d,
                        ElementAt = e,
                        All = f,
                        Any = g,
                        Take = i
                  });
            }
      }
}