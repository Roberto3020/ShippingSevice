using Tranversal.Model.Request;

namespace DataAccess.Abstract
{
    public interface IPaqueteRepository
    {
        Task<int> CreatePaquete(PaqueteRequest request);
    }
}
