using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace CRUD.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    //[EnableCors("permitir")]

    public class EmpleadosController : Controller
    {
        [HttpGet]
        public ActionResult Get()
        {
            using (Models.ControlEmpleadosContext db = new Models.ControlEmpleadosContext()) //Coneccion a la BD 
            {
                var lst = (from d in db.TbEmpleados
                           select d).ToList();

                return Ok(lst); //Convierte automaticamente a un JSON
            }
        }

        [HttpPost]
        public ActionResult Post([FromBody] Models.Request.EmpleadosRequest model)
        {
            using (Models.ControlEmpleadosContext db = new Models.ControlEmpleadosContext())
            {
                Models.TbEmpleados oEmpleados = new Models.TbEmpleados();
                oEmpleados.CodigoEmp = model.CodigoEmp;
                oEmpleados.NombreEmp = model.NombreEmp;
                oEmpleados.ApellidoEmp = model.ApellidoEmp;
                oEmpleados.IdDepto = model.idDepto;
                db.TbEmpleados.Add(oEmpleados); //Insert
                db.SaveChanges(); //Guardar cambios en la base de datos 
            }

            return Ok();
        }

        [HttpPut]
        public ActionResult Put([FromBody] Models.Request.EmpleadosEditRequest model)
        {
            using (Models.ControlEmpleadosContext db = new Models.ControlEmpleadosContext())
            {
                Models.TbEmpleados oEmpleados = db.TbEmpleados.Find(model.IdEmp);
                oEmpleados.CodigoEmp = model.CodigoEmp;
                oEmpleados.NombreEmp = model.NombreEmp;
                oEmpleados.ApellidoEmp = model.ApellidoEmp;
                db.Entry(oEmpleados).State = Microsoft.EntityFrameworkCore.EntityState.Modified; //Update
                db.SaveChanges(); //Guardar cambios en la base de datos 
            }

            return Ok();
        }

        [HttpDelete]
        public ActionResult Delete([FromBody] Models.Request.EmpleadosEditRequest model)
        {
            using (Models.ControlEmpleadosContext db = new Models.ControlEmpleadosContext())
            {
                Models.TbEmpleados oEmpleados = db.TbEmpleados.Find(model.IdEmp);
                db.TbEmpleados.Remove(oEmpleados); //Eliminar registro
                db.SaveChanges(); //Guardar cambios en la base de datos 
            }

            return Ok();
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
