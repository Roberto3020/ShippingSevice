using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tranversal.DTO.Request
{
    public class DireccionRequestDTO
    {
        public string Calle { get; set; }
        public string Pais { get; set; }
        public string Ciudad { get; set; }
        public string Departamento { get; set; }
        public Guid DestinarioId { get; set; }
    }
}
