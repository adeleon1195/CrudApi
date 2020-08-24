﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CRUD.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class EmpleadosController : Controller
    {
        [HttpGet]
        public ActionResult Get()
        {
            using (Models.ControlEmpleadosContext db = new Models.ControlEmpleadosContext()) //Coneccion a la BD 
            {
                var lst = (from d in db.TbDepartamentos
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
                db.TbEmpleados.Add(oEmpleados); //Insert
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