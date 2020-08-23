using System;
using System.Collections.Generic;

namespace CRUD.Models
{
    public partial class TbDepartamentos
    {
        public TbDepartamentos()
        {
            TbEmpleados = new HashSet<TbEmpleados>();
        }

        public int IdDepto { get; set; }
        public string CodigoDepto { get; set; }
        public string NombreDepto { get; set; }
        public string DescripDepto { get; set; }

        public virtual ICollection<TbEmpleados> TbEmpleados { get; set; }
    }
}
