using System;
using System.Collections.Generic;

namespace WSProveedorApi.Models
{
    public partial class Proveedor
    {
        public int Iidproveedor { get; set; }
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public string Empresa { get; set; }
        public int? Bhabilitado { get; set; }
    }
}
