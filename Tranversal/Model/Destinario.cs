using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tranversal.Model
{
    public class Destinario
    {
        public int DestinarioId { get; set; }
        public int IdDireccion { get; set; }
        public string ContactoNombreCompleto { get; set; }
        public string Telefono { get; set; }
        public string Departamento { get; set; }
        public string Ciudad { get; set; }
        public string Correo { get; set; }

        public DateTime FechCreacion { get; set; }
    }
}
