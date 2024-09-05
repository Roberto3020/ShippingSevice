using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tranversal.Model.Request
{
    public class PaqueteRequest
    {
        public string Descripcion { get; set; }
        public double Peso { get; set; }
        public int RemitenteId { get; set; }
        public int DestinarioId { get; set; }
        public int TipoPaqueteId { get; set; }
        public int Cantidad { get; set; }
    }
}
