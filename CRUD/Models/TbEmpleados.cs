using System;
using System.Collections.Generic;

namespace CRUD.Models
{
    public partial class TbEmpleados
    {
        public int IdEmp { get; set; }
        public string CodigoEmp { get; set; }
        public string NombreEmp { get; set; }
        public string ApellidoEmp { get; set; }
        public DateTime? FechaNacEmp { get; set; }
        public int IdDepto { get; set; }

        public virtual TbDepartamentos IdDeptoNavigation { get; set; }
    }
}
