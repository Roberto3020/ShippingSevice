using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tranversal.Model.Request
{
    public class RemitenteRequest
    {
        public string ContactoNombre { get; set; }

        public int IdDireccion { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
    }
}
