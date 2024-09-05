using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tranversal.Model.Request
{
    public class PaqueteCreateRequest
    {
        public PaqueteRequest paquete { get; set; }
        public RemitenteRequest remitente { get; set; }
        public DestinarioRequest destinario { get; set; }
    }
}
