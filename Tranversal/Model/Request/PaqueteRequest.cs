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
        public Guid RemitenteId { get; set; }
        public Guid DestinarioId { get; set; }
        public int TipoPaqueteId { get; set; }
        public int Cantidad { get; set; }
        public double Valor { get; set; }
    }
}
