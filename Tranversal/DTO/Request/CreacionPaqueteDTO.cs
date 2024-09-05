using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tranversal.Model.Request;

namespace Tranversal.DTO.Request
{
    public class CreacionPaqueteDTO
    {
        public PaqueteRequestDTO paquete { get; set; }
        public RemitenteRequestDTO remitente { get; set; }
        public DestinarioRequestDTO destinario { get; set; }
    }
}
