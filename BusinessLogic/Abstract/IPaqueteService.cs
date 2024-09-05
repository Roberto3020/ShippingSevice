using BusinessLogic.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tranversal.Model.Request;

namespace BusinessLogic.Abstract
{
    public interface IPaqueteService
    {
        Task<ServiceResponse<string>> CrearPaquete(PaqueteCreateRequest request);
    }
}
