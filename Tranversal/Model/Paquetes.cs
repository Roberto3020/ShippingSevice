using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tranversal.Model
{
    public class Paquetes
    {
        public int IdPaquetes { get; set; }

        public string Descripcion { get; set; }

        public double Peso { get; set; }
        public int Cantidad { get; set; }
        public int RemitenteId { get; set; }
        public int DestinarioId { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaEnvio { get; set; }
        public int TipoPaquete { get; set; }
        public int EstadoPaqute { get; set; }

    }
}
