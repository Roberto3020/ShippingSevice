using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tranversal.Model.Request
{
    public class DestinarioRequest
    {
        public string ContactoNombre { get; set; }

        public int IdDireccion { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
    }
    public class RemitenteRequest
    {
        public string NombreCompleto { get; set; }

        public int Departamento { get; set; }
        public string Telefono { get; set; }
        public string Ciudad { get; set; }
    }
}
