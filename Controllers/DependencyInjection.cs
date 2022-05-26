using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_Workshop.Data;
using API_Workshop.DI;
using API_Workshop.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_Workshop.DI
{
      public interface ITransientService
      {
            Guid GetID();
      }
      public interface IScopedService
      {
            Guid GetID();
      }

      public interface ISingletonService
      {
            Guid GetID();
      }
      public class DependencyInjection : ITransientService, IScopedService, ISingletonService
      {
            public ITransientService T1 { get; }
            public IScopedService S1 { get; }
            public ISingletonService C1 { get; }
            Guid id;
            public DependencyInjection()
            {
                  id = Guid.NewGuid();

            }
            Guid ITransientService.GetID()
            {
                  return id;
            }
            Guid IScopedService.GetID()
            {
                  return id;
            }
            Guid ISingletonService.GetID()
            {
                  return id;
            }
      }
}
namespace API_Workshop.Controllers
{
      [ApiController]
      [Route("[controller]")]
      public class DIController : ControllerBase
      {
            public ITransientService _ts { get; }
            public ITransientService _ts2 { get; }
            public IScopedService _ss { get; }
            public IScopedService _ss2 { get; }
            public ISingletonService _cs { get; }
            public ISingletonService _cs2 { get; }

            public DIController(ITransientService t1, ITransientService t2, IScopedService s1, IScopedService s2, ISingletonService c1, ISingletonService c2)
            {
                  _ts = t1;
                  _ts2 = t2;
                  _ss = s1;
                  _ss2 = s2;
                  _cs = c1;
                  _cs2 = c2;
            }

            [HttpGet("DiTest")]
            public IActionResult DiTest([FromQuery] int id)
            {
                  switch (id)
                  {
                        case 1:
                              {
                                    var x = _ts.GetID();
                                    var y = _ts2.GetID();
                                    return Ok(new
                                    {
                                          X = x,
                                          Y = y
                                    });

                              }
                        case 2:
                              {
                                    var x = _ss.GetID();
                                    var y = _ss2.GetID();
                                    return Ok(new
                                    {
                                          X = x,
                                          Y = y
                                    });
                              }
                        case 3:
                              {
                                    var x = _cs.GetID();
                                    var y = _cs2.GetID();
                                    return Ok(new
                                    {
                                          X = x,
                                          Y = y
                                    });

                              }
                        default:
                              return Ok(new
                              {
                                    Transient1 = _ts.GetID(),
                                    Transient2 = _ts2.GetID(),
                                    Scoped1 = _ss.GetID(),
                                    Scoped2 = _ss2.GetID(),
                                    Singleton1 = _cs.GetID(),
                                    Singleton2 = _cs2.GetID(),
                              });
                  }
            }

      }
}

