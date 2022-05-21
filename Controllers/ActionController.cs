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

      }
}
