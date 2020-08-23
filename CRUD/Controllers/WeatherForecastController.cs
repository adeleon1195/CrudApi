using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CRUD.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        [HttpGet]
        public ActionResult Get()
        {
            using (Models.ControlEmpleadosContext db = new Models.ControlEmpleadosContext())
            {
                var lst = (from d in db.TbDepartamentos
                          select d).ToList();

                return Ok(lst); //Convierte automaticamente a un JSON
            }
        }
    }
}
