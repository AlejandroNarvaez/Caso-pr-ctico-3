using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WSProveedorApi.Classes
{
    public class ProveedorCLS
    {
        [Display(Name = "Id")]
        public int iidproveedor { get; set; }
        [Display(Name = "Nombre")]
        public string nombre { get; set; }
        [Display(Name = "Telefono")]
        public string telefono { get; set; }
        [Display(Name = "Razón Social")]
        public string empresa { get; set; }


        /*insertar datos*/
        [Display(Name ="Direccion")]
        public string direccion { get; set; }
        
    }
}
