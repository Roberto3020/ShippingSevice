using Tranversal.Model;
using Tranversal.Model.Request;

namespace DataAccess.Abstract
{
    public interface IRemitenteRepository
    {
        Task<ResponseCreate> CreateRemitente(RemitenteRequest request);
    }
}
