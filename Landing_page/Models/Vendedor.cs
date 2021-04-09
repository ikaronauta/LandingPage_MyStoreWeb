using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Landing_page.Models
{
    public class Vendedor
    {
        public int Id_vendedor { get; set; }
        public string Nombre_tienda { get; set; }
        public string Categoria_tienda { get; set; }
        public string Nombres_vendedor { get; set; }
        public string Apellidos_vendedor { get; set; }
        public string Correo_vendedor { get; set; }
        public string Celular_vendedor { get; set; }
    }
}