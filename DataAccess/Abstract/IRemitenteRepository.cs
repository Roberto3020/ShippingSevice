using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tranversal.Model.Request;

namespace DataAccess.Abstract
{
    public interface IRemitenteRepository
    {
        Task<int> CreateRemitente(RemitenteRequest request);
    }
}
