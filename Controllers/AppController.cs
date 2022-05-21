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
      public class AppController : ControllerBase
      {
            public DbxContext _context { get; }
            public AppController(DbxContext context)
            {
                  _context = context;
            }

            [HttpGet("SelectAll")]
            public IActionResult SelectAll()
            {
                  var x = _context.Employees.Select(s => s);
                  return Ok(x);
            }

            [HttpGet("Find")]
            public IActionResult Find([FromQuery] int id)
            {
                  var x = _context.Employees.Find(id);
                  return Ok(x);
            }


            [HttpPost("PostEmployee")]
            public IActionResult Post([FromBody] employee e)
            {
                  if (e == null) return BadRequest("Invalid Details");
                  if (_context.Employees.Find(e.EmployeeID) != null)
                  {
                        return BadRequest("Employee Already Exists !");
                  }
                  else
                  {
                        var x = _context.Employees.Add(e);
                        return Ok(x);
                  }
            }

            // {
            //       "employeeID": 100,
            //       "first_Name": "Pincher",
            //       "last_Name": "King",
            //       "email": "SKING",
            //       "phone_Number": "515.123.4567",
            //       "hire_Date": "1987-06-17T00:00:00",
            //       "job_Id": "AD_PRES",
            //       "salary": 24000,
            //       "commission_PCT": 0,
            //       "manager_ID": 0,
            //       "department_ID": 90
            // }
            [HttpPut("PutEmployee")]
            public IActionResult put([FromBody] employee e)
            {
                  if (e == null) return BadRequest("Invalid Details");

                  var f = _context.Employees.AsNoTracking().First(o => o.EmployeeID == e.EmployeeID);
                  if (f != null)
                  {
                        _context.Employees.Update(e);
                        _context.SaveChanges();
                        return Ok("Updated !!!");
                  }
                  return NotFound("Employee Doesn't Exists !");
            }



            [HttpDelete("DeleteEmployee")]
            public IActionResult delete([FromBody] employee e)
            {
                  if (e == null) return BadRequest("Invalid Details");
                  if (_context.Employees.Find(e.EmployeeID) != null)
                  {
                        var x = _context.Employees.Remove(e);
                        return Ok("Deleted ");
                  }
                  return NotFound("Employee NotFound");

            }
      }
}