using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseModel.Models
{
    public class Preguntas
    {
        public int idPregunta { get; set; }
        public int idUsuario { get; set; }
        public string? pregunta { get; set; }
        public string? nombreUsuario { get; set; }
        public int estado { get; set; }
        public bool Activo { get; set; }
    }
}
