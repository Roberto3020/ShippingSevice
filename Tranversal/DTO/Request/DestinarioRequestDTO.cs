using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tranversal.DTO.Request
{
    public class DestinarioRequestDTO
    {
        public string ContactoNombre { get; set; }
        public Guid IdDireccion { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public int TipoIdentificacion { get; set; }
        public string Identificacion { get; set; }
    }
}
