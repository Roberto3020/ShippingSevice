using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tranversal.Model
{
    public class Remitente
    {
        public int RemitenteId { get; set; }
        public string NombreCompleto { get; set; }
        public string Telefono { get; set; }
        public string Departamento { get; set; }
        public string Ciudad { get; set; }
        public DateTime FechCreacion { get; set; }
    }
}
