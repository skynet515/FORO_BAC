using DataBaseModel.Criptografia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseModel
{
    public class ConexionSQL
    {
        public static string Conexion()
        {
            string conn = Criptografia.Criptografia.Decrypt(Criptografia.Criptografia.cadenaConexion);
            return conn;
        }
    }
}
