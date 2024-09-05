using Tranversal.Model.Request;

namespace DataAccess.Abstract
{
    public interface IRemitenteRepository
    {
        Task<int> CreateRemitente(RemitenteRequest request);
    }
}
