using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD.Models.Request
{
    public class EmpleadosEditRequest
    {
        public int IdEmp { get; set; }
        public string CodigoEmp { get; set; }
        public string NombreEmp { get; set; }
        public string ApellidoEmp { get; set; }
        public int idDepto { get; set; }
    }
}
