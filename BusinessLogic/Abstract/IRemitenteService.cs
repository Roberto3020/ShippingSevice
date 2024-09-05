using BusinessLogic.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tranversal.Model.Request;

namespace BusinessLogic.Abstract
{
    public interface IRemitenteService
    {
        Task<ServiceResponse<string>> CreateRemitente(RemitenteRequest request);
    }
}
