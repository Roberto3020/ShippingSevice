using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tranversal.Model;
using Tranversal.Model.Request;

namespace DataAccess.Abstract
{
    public interface IDestinarioRepository
    {
        Task<ResponseCreate> CreateDestinario(DestinarioRequest request);
    }
}
