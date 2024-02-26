using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseModel.Models
{
    public class Respuesta
    {
        public int idPregunta { get; set; }
        public int idRespuesta { get; set; }
        public string? respuesta { get; set; }
        public int usuarioCreacion { get; set; }
        public string? nombreUsuario { get; set; }
    }
}
