using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseModel.Models
{
    public class Usuario
    {
        public int idUsuario { get; set; }
        public string nombreUsuario { get; set; }
        public string clave { get; set; }
        public string nombreRol { get; set; }
        public int idRol { get; set; }
    }
}
