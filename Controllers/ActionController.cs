using API_Workshop.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Workshop.Controllers
{
      [ApiController]
      [Route("[controller]")]
      public class ActionController : ControllerBase
      {
            private readonly DbxContext _context;

            public ActionController(DbxContext context)
            {
                  _context = context;
            }

            // Action results
            [HttpGet("OKResult")]
            public async Task<IActionResult> ActionResult(int id)
            {
                  switch (id)
                  {
                        case 1: return Ok("It's OKay");
                        case 2: return BadRequest("You are Wrong");
                        case 3: return Unauthorized("Unauthorized");
                        case 4: return NotFound("404 Can't get It");
                        case 5: return NoContent();
                        case 6: return new OkObjectResult(new { Content = "It's OKay", Extra = 200 });
                        case 7: return new BadRequestObjectResult(new { Content = "You are Wrong", Extra = 300 });
                        case 8: return new UnauthorizedObjectResult(new { Content = "Unauthorized", Extra = 201 });
                        case 9: return new NotFoundObjectResult(new { Content = "404 Can't get It", Extra = 404 });
                        case 10: return Redirect("Goto to hell");
                        case 11: return RedirectToRoute("/Action/RedirectOkay");
                        case 12:
                              {
                                    var Location = "C:\\Users\\vinos\\Downloads\\brand-main.zip";
                                    var fileName = System.IO.Path.GetFileName(Location);
                                    var content = await System.IO.File.ReadAllBytesAsync(Location);

                                    return File(content, "application/zip", fileName);
                              }
                  }

                  return BadRequest();
            }

            [HttpGet("RedirectOkay")]
            public IActionResult SampleRedirect(int id)
            { return Ok("You Are OKay"); }

      }
}
